using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ride
{
    class Bicycle : Bike
    {

        public Bicycle() : base()
        {
            Console.WriteLine(status);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("GO!");
        }

        string status = "KEEP CAPSLOCK ON";

        public override string Input()
        {
            string action = Console.ReadLine();
            return action;
        }

        public override int Speedup(int initialSpeed)
        {

            int finalSpeed;
            switch (gear)
            {
                case 1:
                    if (initialSpeed < 10)
                        finalSpeed = initialSpeed + 3;      // Suitable gear gives a good acceleration
                    else finalSpeed = initialSpeed + 1;     // Others doesn't
                    break;
                case 2:
                    if (initialSpeed < 15 && initialSpeed > 5)
                        finalSpeed = initialSpeed + 3;
                    else finalSpeed = initialSpeed + 1;
                    break;
                case 3:
                    if (initialSpeed < 20 && initialSpeed > 10)
                        finalSpeed = initialSpeed + 3;
                    else finalSpeed = initialSpeed + 1;
                    break;
                case 4:
                    if (initialSpeed < 25 && initialSpeed > 15)
                        finalSpeed = initialSpeed + 3;
                    else finalSpeed = initialSpeed + 1;
                    break;
                case 5:
                    if (initialSpeed < 33 && initialSpeed > 20)
                        finalSpeed = initialSpeed + 3;
                    else finalSpeed = initialSpeed + 1;
                    break;
                case 6:
                    if (initialSpeed < 38 && initialSpeed > 30)
                        finalSpeed = initialSpeed + 3;
                    else finalSpeed = initialSpeed + 1;
                    break;
                default:
                    finalSpeed = initialSpeed;
                    break;
            }
            return finalSpeed;
        }

        public override int ChangeGear(int initialGear, int change)
        {
            int finalGear = initialGear + change;
            if (finalGear < 1 || finalGear > 6) finalGear = initialGear;
            return finalGear;
        }

        public override void Damage()
        {
            damaged = 100;
            status = "** WRECKED **";
        }

        public override void DisplayTime(object source, ElapsedEventArgs e)
        {
            if (damaged < 100 && time >= 1)
            {
                time -= 1;
                dist += speed;
                sb -= speed;        // speed breaker is getting closer each second
                if (sb <= 0)
                {

                    sb = r.Next(70, 150);

                    if (speed > 20)
                        Damage();
                }
                Display();
            }
            else if (count == 0)
            {
                Score();
                count++;
            }
        }

        public override void Display()
        {
            Console.Clear();
            Console.WriteLine();
            if (gear == 0) Console.Write("\t\tGear: N");
            else Console.Write("\t\tGear: " + gear);
            Console.WriteLine("\t\t\t\t\tTime: " + time + " sec");
            Console.Write("\t\tSpeed: " + speed + " m/s");
            Console.WriteLine("\t\t\t\tDistance: " + dist + " m");
            Console.Write("\t\tSpeed Braker: " + sb + " m");
            Console.WriteLine("\t\t\t" + status);
        }

        public override void Score()
        {
            string path = "BScores.txt";
            System.IO.File.AppendAllText(path, dist.ToString() + System.Environment.NewLine);
            Display(path, dist);
        }        
    }
}
