using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    interface IRun
    {
      //  void Go();
        int Speedup(int initialSpeed);
        int ApplyBrakes(int initialSpeed);
        int ChangeGear(int initialGear, int change);
    }
}
