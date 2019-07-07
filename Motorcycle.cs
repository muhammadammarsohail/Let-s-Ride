using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Motorcycle : Bike
    {
        public override void Damage()
        {
            damaged += speed - 20;
            if (damaged < 0) damaged = 0;
            if (damaged > 100) damaged = 100;
        }
    }
}
