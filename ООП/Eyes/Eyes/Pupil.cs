using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Eyes
{
    class Pupil
    {
        private float x, y;
        private float centx, centy;
        private float size, eyeSize;
        public Pupil(float ax, float ay, float asize, float aeyeSize)
        {
            size = asize;
            eyeSize = aeyeSize;
            centx = ax;
            x = ax;
            centy = ay;
            y = ay;
            
        }
        public void Move(float mx, float my)
        {
            float l = (float)Math.Sqrt((mx - centx) * (mx - centx) + (my - centy) * (my - centy)) * 0.2f;
            if (l < eyeSize / 2 - size / 2)
            {
                x = centx + (mx - centx) * 0.2f;
                y = centy + (my - centy) * 0.2f;
            }
            else
            {
                x = centx + (mx - centx) * ((eyeSize - size) / (3 * l * 5f));
                y = centy + (my - centy) * ((eyeSize - size) / (3 * l * 5f));
            }
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, x - size / 2, y - size / 2, size, size); ;
        }
    }
}
