using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Program
    {
        static void Main(string[] args)
        {
            string vehicle = Console.ReadLine();
            switch (vehicle)
            {
                case "bicycle":
                    Bicycle bi = new Bicycle();
                    break;

                case "motorcycle":
                    Motorcycle motor = new Motorcycle();
                    break;

                default:
                    Console.WriteLine("You don't have the vehicle");
                    break;


            }
                

        }
    }
}
