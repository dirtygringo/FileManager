using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace FileEngine.Extensions
{
    public static class PropertyExtensions 
    {
        public static PropertyInfo GetPropertyByName(this Type type, string propertyName)
        {
            return type
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                    .SingleOrDefault(x => x.Name == propertyName);
        }

        public static void SetPropertyFromString(this PropertyInfo property, object obj, string value)
        {
            var typeConverter = TypeDescriptor.GetConverter(property.PropertyType);
            property.SetValue(obj, typeConverter.ConvertFromString(value));
        }
    }
}
