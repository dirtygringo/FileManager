using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using System.Collections.Generic;
using FileEngine.Exceptions;
using FileEngine.Extensions;

namespace FileEngine.Parsers.Concrete
{
    public class XmlParser : IParser
    {
        #region Methods

        public IEnumerable<T> Parse<T>(string filepath) where T : class, new()
        {
            if (!File.Exists(filepath)) throw new FileNotFoundException("Invalid file path");

            var list = new List<T>();
            var xDocument = XDocument.Load(filepath);

            if (xDocument == null) throw new EmptyFileException("File is empty");

            xDocument.Elements().ToList().ForEach(element =>
            {
                var model = new T();
                model = TraverseElements<T>(element, model);
                list.Add(model);
            });
            return list;
        }

        #region HelperMethods

        private static T TraverseElements<T>(XElement element, T model) where T : class, new()
        {
            MethodInfo methodInfo;
            element.Elements().ToList().ForEach(e =>
            {
                var property = model.GetType().GetPropertyByName(e.Name.LocalName);
                if (property == null) throw new PropertyNotFoundException("Invalid property name");

                methodInfo = property.GetGetMethod();
                if (methodInfo.ReturnType.IsArray)
                {
                    var type = property.PropertyType.GetElementType();
                    var array = Array.CreateInstance(property.PropertyType.GetElementType(), e.Elements().Count());
                    for (int i = 0; i < array.Length; i++)
                    {
                        array.SetValue(Activator.CreateInstance(array.GetType().GetElementType()), i);
                    }
                    property.SetValue(model, array);
                    TraverseArrayElements(e.Elements().ToArray(), array);
                }
                else if (methodInfo.ReturnType.IsClass && methodInfo.ReturnType.UnderlyingSystemType != typeof(string))
                {
                    var instance = Activator.CreateInstance(property.PropertyType);
                    property.SetValue(model, instance);
                    TraverseElements(e, instance);
                }
                else
                {
                    property.SetPropertyFromString(model, e.Value);
                }
            });
            return model;
        }

        private static void TraverseArrayElements(XElement[] elements, Array array)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                TraverseElements(elements[i], array.GetValue(i));
            }
        }

        #endregion

        #endregion
    }
}
