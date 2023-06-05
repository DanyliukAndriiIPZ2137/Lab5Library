using Lab5Library.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Iterator
{
    public interface IIterator
    {
        bool HasNext();
        LightNode Next();
    }
}
