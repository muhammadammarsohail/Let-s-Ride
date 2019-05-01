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
                

                ConsoleKeyInfo k = Console.ReadKey();
             
                char act = (char) k.Key;
             
                if (act == 'S') break;
                switch (act)
                {
                    case 'R':                        
                        speed = Speedup(speed);
                        Console.Clear();
                        Display(gear, speed);
                        break;
                    case 'B':                       
                        speed = ApplyBrakes(speed);
                        Console.Clear();
                        Display(gear, speed);
                        break;
                    case 'U':                       
                        gear = ChangeGear(gear, 1);
                        Console.Clear();
                        Display(gear, speed);
                        break;
                    case 'D':                        
                        gear = ChangeGear(gear , 0-1);
                        Console.Clear();
                        Display(gear, speed);
                        break;
                    default:
                        Console.WriteLine("Put a valid action.");
                        break;
                }  
            } while (true);
        }
        public int Speedup(int initialSpeed)
        {
            
            int finalSpeed = initialSpeed + 5;
            return finalSpeed;
        }

        public int ApplyBrakes(int initialSpeed)
        {
            int finalSpeed = initialSpeed;
            if (initialSpeed < 0)
            finalSpeed = initialSpeed - 5;
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
