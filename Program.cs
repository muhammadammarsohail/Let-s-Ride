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
        static void Main()
        {
            Console.WriteLine("LET'S RIDE");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("MOTORCYCLE or BICYCLE?");
            string vehicle;
            do
            {
                vehicle = Console.ReadLine();
                if (vehicle == "BICYCLE" || vehicle == "Bicycle") vehicle = "bicycle";
                else if (vehicle == "MOTORCYCLE" || vehicle == "Motorcycle") vehicle = "motorcycle";
                else Console.WriteLine("You don't have the vehicle");

            } while (vehicle != "bicycle" && vehicle != "motorcycle");            

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
                    break;
            }

            string end;
            do
            {
                end = Console.ReadLine();
            } while (end != "quit" && end != "QUIT" || end != "Quit");

        }
    }
}
