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
        string act;
        public static int speed = 0, gear = 0, time = 61, dist = 0, sb, damaged, count = 0;
        static protected Random r = new Random();
        static Timer t = new Timer();

        public Bike()
        {
            Console.Clear();
            Console.WriteLine("READY!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("STEADY!");
            System.Threading.Thread.Sleep(1000);
        }

        public abstract string Input();

        public abstract int Speedup(int initialSpeed);

        public abstract void Damage();

        public void Go()
        {
            t.Elapsed += new ElapsedEventHandler(DisplayTime);
            t.Interval = 1000; // 1000 ms is one second
            t.Start();

            do
            {
                act = Input();

                switch (act)
                {
                    case "W":
                        speed = Speedup(speed);
                        Display();
                        break;

                    case "S":
                        speed = ApplyBrakes(speed);
                        Display();
                        break;

                    case "D":
                        gear = ChangeGear(gear, 1);
                        Display();
                        break;

                    case "A":
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

        public virtual int ChangeGear(int initialGear, int change)
        {
            int finalGear = initialGear + change;
            if (finalGear < 0 || finalGear > 4) finalGear = initialGear;
            return finalGear;
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
                if (damaged < 100 && time > 0)
                {
                    time -= 1;
                    dist += speed;
                    sb -= speed;
                    if (sb <= 0)
                    {    

                        if (speed > 20)
                            Damage();

                        if (damaged < 100)
                            sb = r.Next(500, 1500);   // The next speed breaker
                        else sb = 0;
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

        public virtual void Score()
        {
            string path = "MScores.txt";
            System.IO.File.AppendAllText(path, dist.ToString() + System.Environment.NewLine);
            Display(path, dist);
        }

        public virtual void Display()
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
            {
                int a = Convert.ToInt32(hist[i]);
                if (a > best) best = a;
            }

            Console.WriteLine("\n\n\t\t\t\t   Game Over!");
            Console.WriteLine("\n\t\t\t\tYour Score: " + score);
            Console.WriteLine("\t\t\t\tBest Score: " + best);

        }
    }
}
