using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.IImageLoadingStrategy
{
    public interface IImageLoadingStrategy
    {
        void LoadImage(string href);
    }
}
