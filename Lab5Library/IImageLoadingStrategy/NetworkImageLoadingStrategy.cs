using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab5Library.IImageLoadingStrategy
{
    public class NetworkImageLoadingStrategy : IImageLoadingStrategy
    {
        public async void LoadImage(string href)
        {
            Console.WriteLine($"Photo from internet {href}");
        }
    }
}
