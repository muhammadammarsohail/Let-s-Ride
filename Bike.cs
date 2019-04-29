using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Bike : IVehicle
    {
        public int speed, gear;
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
