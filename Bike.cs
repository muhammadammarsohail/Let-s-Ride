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
                        //   Console.Clear();
                        Display();
                        break;
                    case 'S':
                        speed = ApplyBrakes(speed);
                        //    Console.Clear();
                        Display();
                        break;
                    case 'D':
                        gear = ChangeGear(gear, 1);
                        //       Console.Clear();
                        Display();
                        break;
                    case 'A':
                        gear = ChangeGear(gear, 0 - 1);
                        //      Console.Clear();
                        Display();
                        break;
                    default:
                        Console.WriteLine("Put a valid action.");
                        break;
                }

            } while (damaged < 100 && time > 0);

            Display();
            t.Enabled = false;
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

        public abstract int ChangeGear(int initialGear, int change);

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Gear: " + gear + "th");
            Console.WriteLine("Speed: " + speed + "m/s");
            Console.WriteLine("Time: " + time + "s");
            Console.WriteLine("Distance: " + dist + "m");
            Console.WriteLine("Speed Braker: " + sb + "m");
            Console.WriteLine("Damaged: " + damaged + "%");
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
                        sb = r.Next(500, 1500);

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

        public abstract void Score();

        protected void Display(string path, int score)
        {
            string[] his = System.IO.File.ReadAllLines(path);

            int best = 0;
            for (int i = 0; i < his.Length; i++)
                if (Convert.ToInt32(his[i]) > best) best = Convert.ToInt32(his[i]);            

            Console.WriteLine("Your Score: " + score);
            Console.WriteLine("Best Score: " + best);

        }
    }
}
