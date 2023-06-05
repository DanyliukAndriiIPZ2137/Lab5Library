using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Observer
{
    public class LightElementObserver : IObserver
    {
        private string _name;

        public LightElementObserver(string name)
        {
            _name = name;
        }

        public void Update(string state)
        {
            Console.WriteLine($"{_name} received update: {state}");
        }
    }

}
