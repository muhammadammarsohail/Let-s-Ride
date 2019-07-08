using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride
{
    class Motorcycle : Bike
    {
        public override void Damage()
        {
            damaged += speed - 20;   // damaged = damaged + speed -20;
         //   if (damaged < 0) damaged = 0;
            if (damaged > 100) damaged = 100;
        }

        public override int ChangeGear(int initialGear, int change)
        {
            int finalGear = initialGear + change;
            if (finalGear < 0 || finalGear > 4) finalGear = initialGear;
            return finalGear;
        }

        public override void Score()
        {
            int score = dist + (100 - damaged) + time;
            string path = "MScores.txt";
            System.IO.File.AppendAllText(path, score.ToString() + System.Environment.NewLine);
            Display(path, score);
        }

}
}
