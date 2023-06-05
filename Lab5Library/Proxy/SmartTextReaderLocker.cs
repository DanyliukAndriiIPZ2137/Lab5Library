using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab5Library.Proxy
{
    public class SmartTextReaderLocker : ITextReader
    {
        private readonly ITextReader _reader;
        private readonly Regex _regex;

        public SmartTextReaderLocker(ITextReader reader, Regex regex)
        {
            _reader = reader;
            _regex = regex;
        }

        public char[][] ReadFile(string path)
        {
            if (_regex.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }

            return _reader.ReadFile(path);
        }
    }
}
