using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ride
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to ride?");
            string vehicle = Console.ReadLine();
            switch (vehicle)
            {
                case "bicycle":
                    Bicycle bi = new Bicycle();
                    Bike.gear = 1;
                    bi.Go();
                    bi.Display();
                    bi.Score();
                    break;

                case "motorcycle":
                    Motorcycle motor = new Motorcycle();
                    motor.Go();
                    motor.Display();
                    motor.Score();
                    break;

                default:
                    Console.WriteLine("You don't have the vehicle");
                    Console.ReadKey();
                    break;


            }

            Console.ReadLine();

        }
    }
}
