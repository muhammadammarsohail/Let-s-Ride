﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    interface IPlay
    {
        void Go();
        string Input();
        void Damage();
        void Display();
        void Score();
    }
}
