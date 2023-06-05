using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Proxy
{
    public class SmartTextReader : ITextReader
    {
        public char[][] ReadFile(string path)
        {
            List<char[]> lines = new List<char[]>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line.ToCharArray());
                }
            }

            return lines.ToArray();
        }
    }
}
