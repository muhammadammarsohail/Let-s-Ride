using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Bike : IVehicle
    {
        public int speed = 0, gear = 0;
        public void Go()
        {
            do {
            string action = Console.ReadLine();
            char act = action[0];
                if (act == 's') break;
                switch (act)
                {
                    case 'r':
                        int intensityR = action.Length * 5;
                        speed = Speedup(speed, intensityR);
                        Display(gear, speed);
                        break;
                    case 'b':
                        int intensityBr = action.Length * 5;
                        speed = ApplyBrakes(speed, intensityBr);
                        Display(gear, speed);
                        break;
                    case 'u':
                        int shiftU = action.Length;
                        gear = ChangeGear(gear, shiftU);
                        Display(gear, speed);
                        break;
                    case 'd':
                        int shiftD = 0 - action.Length;
                        gear = ChangeGear(gear, shiftD);
                        Display(gear, speed);
                        break;
                    default:
                        Console.WriteLine("Put a valid action.");
                        break;
                }  
            } while (true);
        }
        public int Speedup(int initialSpeed, int intensity)
        {
            int finalSpeed = initialSpeed + intensity;
            return finalSpeed;
        }

        public int ApplyBrakes(int initialSpeed, int intensity)
        {
            int finalSpeed = initialSpeed - intensity;
            return finalSpeed;
        }

        public int ChangeGear(int initialGear, int change)
        {
            int finalGear = initialGear + change;
            return finalGear;
        }

        public void Display(int gear, int speed)
        {
            Console.WriteLine("Gear: " + gear);
            Console.WriteLine("Speed: " + speed);
        }

    }
}
