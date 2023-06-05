using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Proxy
{
    public class SmartTextChecker : ITextReader
    {
        private readonly ITextReader _reader;
        public SmartTextChecker(ITextReader reader)
        {
            _reader = reader;
        }
        public char[][] ReadFile(string filePath)
        {
            Console.WriteLine($"Opening file {filePath}...");
            char[][] result = _reader.ReadFile(filePath);
            Console.WriteLine($"Closing file {filePath}...");
            Console.WriteLine($"Total lines: {result.Length}\nTotal characters: {result.Sum(line => line.Length)}");
            return result;
        }
    }
}
