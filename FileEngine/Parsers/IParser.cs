using System.Collections.Generic;

namespace FileEngine.Parsers
{
    public interface IParser 
    {
        IEnumerable<T> Parse<T>(string filepath) where T : class, new();
    }
}
