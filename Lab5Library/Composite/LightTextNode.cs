using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab5Library.Composite
{
    public class LightTextNode : LightNode
    {
        protected string _text { get ; set; }
        public LightTextNode(string text)
        {
            _text = text;
        }
        public override void Print()
        {
            Console.Write(_text);
        }

        public override LightNode Clone()
        {
            return new LightTextNode(_text);
        }
    }
}
