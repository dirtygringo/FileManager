using FileEngine.Parsers;
using System.Collections.Generic;

namespace FileEngine
{
    public class FileManager
    {
        private IParser _parser;

        public FileManager(IParser parser)
        {
            _parser = parser;
        }

        public void SetParser(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<T> Parse<T>(string filepath) where T : class, new()
        {
            return _parser.Parse<T>(filepath);
        }
    }
}
