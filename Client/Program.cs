using Client.Model;
using FileEngine;
using FileEngine.Parsers.Concrete;
using System;
using System.IO;
using System.Collections.Generic;

namespace Client
{
    class Program 
    {
        static void Main(string[] args)
        {
            var engine = new FileManager(new CsvParser());

            while (true)
            {
                var filepath = Console.ReadLine();
                IEnumerable<DataRecords> result = null;

                try
                {
                    switch (Path.GetExtension(filepath))
                    {
                        case ".csv":
                            engine.SetParser(new CsvParser());
                            break;
                        case ".xml":
                            engine.SetParser(new XmlParser());
                            break;
                        case ".txt":
                            engine.SetParser(new TxtParser());
                            break;
                        default:
                            throw new NotImplementedException("Parser not implemented");
                    }
                    result = engine.Parse<DataRecords>(filepath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
