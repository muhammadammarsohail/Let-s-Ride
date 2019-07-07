using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Bicycle : Bike
    {
        public override int Speedup(int initialSpeed)
        {
            int finalSpeed = initialSpeed;
            switch (gear)
            {
                case 1:
                    if (initialSpeed < 10)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                case 2:
                    if (initialSpeed < 15 && initialSpeed > 5)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                case 3:
                    if (initialSpeed < 20 && initialSpeed > 10)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                case 4:
                    if (initialSpeed < 25 && initialSpeed > 15)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                case 5:
                    if (initialSpeed < 33 && initialSpeed > 20)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                case 6:
                    if (initialSpeed < 38 && initialSpeed > 30)
                        finalSpeed = initialSpeed + 3;
                    else if (initialSpeed < 38) finalSpeed = initialSpeed + 1;
                    break;
                default:
                    finalSpeed = initialSpeed;
                    break;
            }
            return finalSpeed;
        }

        //public override void Damage()
        //{
            
        //}
    }
}
