using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Proxy
{
    public interface ITextReader
    {
        char[][] ReadFile(string path);
    }
}
