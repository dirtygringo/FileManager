using System;
using System.Collections.Generic;
using System.Text;

namespace FileEngine.Parsers.Concrete
{
    public class TxtParser : IParser 
    {
        public IEnumerable<T> Parse<T>(string filepath) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
