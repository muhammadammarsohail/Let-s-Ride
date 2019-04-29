using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    interface IVehicle
    {
        void Go();
        int Speedup(int initialSpeed, int intensity);
        int ApplyBrakes(int initialSpeed, int intensity);
        int ChangeGear(int initialGear, int change);
        void Display(int gear, int speed);
    }
}
