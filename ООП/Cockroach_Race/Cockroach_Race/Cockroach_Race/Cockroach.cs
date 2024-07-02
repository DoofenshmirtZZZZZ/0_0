using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cockroach_Race
{
    class Cockroach
    {
        public int Y, X, speed, place;
        public TimeSpan FinishTime;
        Brush BugColor;
        public int raduis = 15;

        public Cockroach(int X, int Y, Brush BugColor)
        {
            this.X = X;
            this.Y = Y;
            this.BugColor = BugColor;
        }
        public void Move()
        {
            Random rnd = new Random(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + X + Y);
            speed = rnd.Next(1, 10);
            X += speed;
            if (X >= 500 + 40)
            {
                X = 500 + 40;
                PlaceAndTime.place++;
                place = PlaceAndTime.place;
                FinishTime = DateTime.Now.Subtract(PlaceAndTime.StartTime);
            }
        }
    }
}
