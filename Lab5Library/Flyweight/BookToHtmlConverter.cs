using Lab5Library.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Flyweight
{
    public class BookToHtmlConverter
    {
        private LightElementNode _root;
        private LightElementNodeFactory _factory;

        public BookToHtmlConverter()
        {
            _root = new LightElementNode("html");
            _factory = new LightElementNodeFactory();
        }

        public void Convert(string bookText)
        {
            var lines = bookText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            bool firstLine = true;

            foreach (var line in lines)
            {
                LightElementNode node;
                if (firstLine)
                {
                    node = _factory.GetNode("h1");
                    firstLine = false;
                }
                else if (line.Length < 20)
                {
                    node = _factory.GetNode("h2");
                }
                else if (line.StartsWith(" "))
                {
                    node = _factory.GetNode("blockquote");
                }
                else
                {
                    node = _factory.GetNode("p");
                }

                node.AppendChild(new LightTextNode(line));
                _root.AppendChild(node);
            }
            long totalMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"Total memory: {totalMemory}");
        }

        public void PrintHtml()
        {
            _root.Print();
        }
    }
}
