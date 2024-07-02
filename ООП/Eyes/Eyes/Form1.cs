using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyes
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Face> faces = new List<Face>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int size = rnd.Next(10, 100);
            Face face = new Face(e.X - size, e.Y - size, 5 * size, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            faces.Add(face);
            Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Face f in faces)
                f.Update(e.X, e.Y);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Face f in faces)
                f.Draw(e.Graphics);
        }
    }
}
