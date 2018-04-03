﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using FileEngine.Extensions;
using FileEngine.Exceptions;

namespace FileEngine.Parsers.Concrete
{
    public class CsvParser : IParser 
    {
        public IEnumerable<T> Parse<T>(string filepath) where T : class, new()
        {
            if (!File.Exists(filepath)) throw new ArgumentException("Invalid file path");

            var readLines = File.ReadLines(filepath).ToList();
            if (readLines.Count == default) throw new EmptyFileException("File is empty");

            var headers = readLines[0].Split(',').Select(x => string.Concat(x.Split(' ')).Trim()).ToArray();

            var list = new List<T>();
            for (int i = 1; i < readLines.Count(); i++)
            {
                var valuesPerLine = readLines[i].Split(',');
                var model = new T();

                for (int j = 0; j < valuesPerLine.Count(); j++)
                {
                    var propertyName = headers[j];
                    var property = model.GetType().GetPropertyByName(propertyName);

                    if (property == null) throw new KeyNotFoundException($"Not valid property name {propertyName}");

                    property.SetPropertyFromString(model, valuesPerLine[j]);
                }
                list.Add(model);
            }
            return list;
        }
    }
}