using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Composite
{
    public abstract class LightNode
    {
        public abstract void Print();
        public abstract LightNode Clone();
    }
}
