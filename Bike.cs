using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Bike : IVehicle
    {
        public int Speedup(int initialSpeed, int intensity)
        {
            int finalSpeed = initialSpeed + intensity * 5;
            return finalSpeed;
        }

        public int ApplyBrakes(int initialSpeed, int intensity)
        {
            int finalSpeed = initialSpeed - intensity * 5;
            return finalSpeed;
        }
    }
}
