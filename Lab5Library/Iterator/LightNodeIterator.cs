using Lab5Library.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Iterator
{
    public class LightNodeIterator : IIterator
    {
        private List<LightNode> _nodes;
        private int _position;

        public LightNodeIterator(List<LightNode> nodes)
        {
            _nodes = nodes;
        }

        public bool HasNext()
        {
            return _position < _nodes.Count;
        }

        public LightNode Next()
        {
            return _nodes[_position++];
        }
    }
}
