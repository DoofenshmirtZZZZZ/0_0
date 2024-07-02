using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Eyes
{
    class Face
    {
        private float x, y;
        private float size;
        private Eye e1, e2;
        private Brush br;
        private Pen pen = new Pen(Color.Black, 1);
        public Face(float ax, float ay, float asize, int r, int g, int b)
        {
            x = ax;
            y = ay;
            size = asize;
            e1 = new Eye(x + size * 0.25f, y + size / 2, size * 0.4f);
            e2 = new Eye(x + size * 0.75f, y + size / 2, size * 0.4f);
            br = new SolidBrush(Color.FromArgb(r, g, b));
        }
        public void Update(float mx, float my)
        {
            e1.Update(mx, my);
            e2.Update(mx, my);
        }
        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen, x, y, size, size);
            g.FillEllipse(br, x, y, size, size);
            g.DrawLine(pen, x + size * 0.50f, y + size * 0.80f, x + size * 0.45f, y + size * 0.80f);
            e1.Draw(g);
            e2.Draw(g);
        }
    }
}
