using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Bicycle : Bike
    {
        public void Go()
        {
            string action = Console.ReadLine();
            char act = action[0];
            switch (act)
            {
                case 'r':
                    break;
                case 'b':
                    break;
                case 'u':
                    break;
                case 'd':
                    break;
            }
        }
    }
}
