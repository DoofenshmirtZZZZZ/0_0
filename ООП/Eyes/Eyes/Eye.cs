using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Eyes
{
    class Eye
    {
        private float x, y;
        private float size;
        private Pen pen = new Pen(Color.Black, 1);
        private Pupil p;
        public Eye(float ax, float ay, float asize)
        {
            x = ax;
            y = ay;
            size = asize;
            p = new Pupil(x, y, size * 0.7f, size); // зрачки данные
        }
        public void Update(float mx, float my)
        {
            p.Move(mx, my);
        }
        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen, x - size / 2, y - size / 2, size, size);
            g.FillEllipse(Brushes.White, x - size / 2, y - size / 2, size, size);
            p.Draw(g);
        }
    }
}
