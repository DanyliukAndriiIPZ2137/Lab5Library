﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Library.Observer
{
    public interface IObserver
    {
        void Update(string state);
    }
}
