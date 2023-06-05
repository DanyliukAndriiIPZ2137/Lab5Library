using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Composite
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public bool IsBlock { get; set; }
        public bool IsSelfClosing { get; set; }
        public List<string> CssClasses { get; set; }
        public List<LightNode> Children { get; set; }

        public LightElementNode(string tagName, bool isBlock = false, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public override void Print()
        {
            Console.Write("<" + TagName);

            if (CssClasses.Count > 0)
            {
                Console.Write(" class=\"" + string.Join(" ", CssClasses) + "\"");
            }

            Console.Write(">");

            if (!IsSelfClosing)
            {
                foreach (var child in Children)
                {
                    child.Print();
                }

                Console.Write("</" + TagName + ">\n");
            }
        }

        public override LightNode Clone()
        {
            var clone = new LightElementNode(TagName, IsBlock, IsSelfClosing);

            foreach (var cssClass in CssClasses)
            {
                clone.CssClasses.Add(cssClass);
            }

            foreach (var child in Children)
            {
                clone.Children.Add(child.Clone());
            }

            return clone;
        }

        public void AppendChild(LightNode node)
        {
            Children.Add(node);
        }

        public void ReplaceChild(LightNode node, LightNode oldNode)
        {
            int index = Children.IndexOf(oldNode);
            if (index >= 0)
            {
                Children[index] = node;
            }
        }

        public void RemoveChild(LightNode node)
        {
            Children.Remove(node);
        }

        public void InsertBefore(LightNode node, LightNode refNode)
        {
            int index = Children.IndexOf(refNode);
            if (index >= 0)
            {
                Children.Insert(index, node);
            }
        }

        public string OuterHtml()
        {
            return ToString();
        }

        public string InnerHtml()
        {
            return string.Join("", Children.Select(x => x.ToString()));
        }

        public override string ToString()
        {
            var cssClasses = string.Join(" ", CssClasses);
            var attributes = string.IsNullOrWhiteSpace(cssClasses) ? "" : $" class=\"{cssClasses}\"";
            var children = string.Join("", Children.Select(x => x.ToString()));

            if (IsSelfClosing)
            {
                return $"<{TagName}{attributes}/>";
            }
            else
            {
                return $"<{TagName}{attributes}>{children}</{TagName}>";
            }
        }
    }
}
