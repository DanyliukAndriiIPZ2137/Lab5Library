using Lab5Library.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Flyweight
{
    public class LightElementNodeFactory
    {
        private Dictionary<string, LightElementNode> _nodes = new Dictionary<string, LightElementNode>();

        public LightElementNode GetNode(string tagName, bool isBlock = false, bool isSelfClosing = false)
        {
            var key = $"{tagName}|{isBlock}|{isSelfClosing}";

            if (!_nodes.ContainsKey(key))
            {
                _nodes[key] = new LightElementNode(tagName, isBlock, isSelfClosing);
            }

            return _nodes[key].Clone() as LightElementNode;
        }
    }
}
