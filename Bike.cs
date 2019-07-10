using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ride
{
    abstract class Bike : IRun, IPlay
    {
        public static int speed = 0, gear = 0, time = 60, dist = 0, sb, damaged, count = 0;
        static protected Random r = new Random();
        static readonly Timer t = new Timer();

        public abstract int ChangeGear(int initialGear, int change);

        public abstract void Score();

        public void Go()
        {
            t.Elapsed += new ElapsedEventHandler(DisplayTime);
            t.Interval = 1000; // 1000 ms is one second
            t.Start();

            do
            {
                ConsoleKeyInfo k = Console.ReadKey();
                char act = (char)k.Key;

                switch (act)
                {
                    case 'W':
                        speed = Speedup(speed);
                        Display();
                        break;

                    case 'S':
                        speed = ApplyBrakes(speed);
                        Display();
                        break;

                    case 'D':
                        gear = ChangeGear(gear, 1);
                        Display();
                        break;

                    case 'A':
                        gear = ChangeGear(gear, 0 - 1);
                        Display();
                        break;

                    default:
                        Console.WriteLine("Put a valid action.");
                        break;
                }

            } while (damaged < 100 && time > 0);

            Display();
            t.Enabled = false;  // Stops the timer
        }

        public virtual int Speedup(int initialSpeed)
        {
            int finalSpeed = initialSpeed;
            switch (gear)
            {
                case 1:
                    if (initialSpeed < 20)
                        finalSpeed = initialSpeed + 5;
                    break;
                case 2:
                    if (initialSpeed < 45 && initialSpeed > 10)
                        finalSpeed = initialSpeed + 5;
                    break;
                case 3:
                    if (initialSpeed < 80 && initialSpeed > 30)
                        finalSpeed = initialSpeed + 5;
                    break;
                case 4:
                    if (initialSpeed < 180 && initialSpeed > 40)
                        finalSpeed = initialSpeed + 5;
                    break;
                default:
                    finalSpeed = initialSpeed;
                    break;
            }
            return finalSpeed;
        }

        public int ApplyBrakes(int initialSpeed)
        {
            int finalSpeed = initialSpeed;
            if (initialSpeed > 0)
                finalSpeed = initialSpeed - 5;
            if (finalSpeed < 0) finalSpeed = 0;
            return finalSpeed;
        }

        public virtual void DisplayTime(object source, ElapsedEventArgs e)
        {
            // code here will run every second
            {
                if (damaged < 100 && time >= 1)
                {
                    time -= 1;
                    dist += speed;
                    sb -= speed;
                    if (sb <= 0)
                    {
                        sb = r.Next(500, 1500);     // The next speed breaker

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
        }

        public virtual void Damage()
        {
            damaged = 100;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine();
            if (gear == 0) Console.Write("\t\tGear: N");
            else Console.Write("\t\tGear: " + gear);
            Console.WriteLine("\t\t\t\t\tTime: " + time + " sec");
            Console.Write("\t\tSpeed: " + speed + " m/s");
            Console.WriteLine("\t\t\t\tDistance: " + dist + " m");
            Console.Write("\t\tSpeed Braker: " + sb + " m");
            Console.WriteLine("\t\t\tDamaged: " + damaged + "%");
        }

        protected void Display(string path, int score)
        {
            string[] hist = System.IO.File.ReadAllLines(path);

            int best = 0;
            for (int i = 0; i < hist.Length; i++)
                if (Convert.ToInt32(hist[i]) > best) best = Convert.ToInt32(hist[i]);

            Console.WriteLine("\n\n\t\t\t\t    Game Over!");
            Console.WriteLine("\n\t\t\t\tYour Score: " + score);
            Console.WriteLine("\t\t\t\tBest Score: " + best);

        }
    }
}
