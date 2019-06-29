﻿using System;
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
            string vehicle = Console.ReadLine();
            switch (vehicle)
            {
                case "bicycle":
                    Bicycle bi = new Bicycle();
                    bi.Go();
                    bi.Display();
                    break;

                case "motorcycle":
                    Motorcycle motor = new Motorcycle();
                    motor.Go();
                    motor.Display();
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
