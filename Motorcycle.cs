using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Motorcycle : Bike
    {
        public Motorcycle() : base()
        {
            Console.WriteLine("GO!");
        }

        public override string Input()
        {
            ConsoleKeyInfo k = Console.ReadKey();
            string action = k.Key.ToString();
            return action;
        }

        public override int Speedup(int initialSpeed)
        {
            int finalSpeed = initialSpeed;
            switch (gear)
            {
                case 1:
                    if (initialSpeed < 20)
                        finalSpeed = initialSpeed + 1;
                    break;
                case 2:
                    if (initialSpeed < 45 && initialSpeed > 9)
                        finalSpeed = initialSpeed + 1;
                    break;
                case 3:
                    if (initialSpeed < 70 && initialSpeed > 34)
                        finalSpeed = initialSpeed + 1;
                    break;
                case 4:
                    if (initialSpeed < 140 && initialSpeed > 59)
                        finalSpeed = initialSpeed + 1;
                    break;
                default:
                    break;
            }
            return finalSpeed;
        }

        public override void Damage()
        {
            damaged += speed - 20;   // 1 m/s of overspeed produces 1% damage
            if (damaged > 100) damaged = 100;
        }
    }
}
