using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab5Library.IImageLoadingStrategy
{
    public class FileSystemImageLoadingStrategy : IImageLoadingStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Photo from system {href}");
        }
    }
}
