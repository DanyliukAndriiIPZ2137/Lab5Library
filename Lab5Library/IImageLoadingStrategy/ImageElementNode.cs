using Lab5Library.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.IImageLoadingStrategy
{
    public class ImageElementNode : LightElementNode
    {
        private IImageLoadingStrategy _loadingStrategy;
        private string _href;

        public ImageElementNode(string href, bool fromFileSystem)
            : base("img", false, true)
        {
            _href = href;
            if (fromFileSystem)
            {
                _loadingStrategy = new FileSystemImageLoadingStrategy();
            }
            else
            {
                _loadingStrategy = new NetworkImageLoadingStrategy();
            }
        }

        public override void Print()
        {
            _loadingStrategy.LoadImage(_href);
            base.Print();
        }
    }
}
