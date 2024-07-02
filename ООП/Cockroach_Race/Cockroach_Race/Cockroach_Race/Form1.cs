using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cockroach_Race
{
	public partial class Form1 : Form
	{
		int N = 0;
		Cockroach[] cockroach = new Cockroach[20];
		Brush[] br = { Brushes.Crimson, Brushes.Aqua, Brushes.Brown, Brushes.DarkGreen, Brushes.DarkSeaGreen, Brushes.DeepPink, Brushes.Black, Brushes.Gold, Brushes.Blue, Brushes.Violet};
		Brush[] bV = { Brushes.Pink, Brushes.Peru, Brushes.Red, Brushes.HotPink, Brushes.LightPink, Brushes.DeepPink, Brushes.LightCoral, Brushes.Purple, Brushes.Blue, Brushes.Violet };
		public Form1()
		{
			 InitializeComponent();
			timer = new Timer();
			timer.Interval = (50);
			timer.Tick += timer_Tick;
			
			 
		}

		public void FieldDraw_Click(object sender, EventArgs e)
		{
			Graphics g = pictureBox1.CreateGraphics();
			N = (int)NCount.Value;
			DrawField(N, g);
			SetCockroach(N, g);
			timer.Start();
			PlaceAndTime.place = 0;
			PlaceAndTime.StartTime = DateTime.Now;
		}
		public void DrawField(int N, Graphics g)
		{
			Pen BlackPen = new Pen(Brushes.Black);
			Pen RedPen = new Pen(Brushes.Red);
			for (int i = 0; i <= N - 1; i++)
				g.FillRectangle(bV[i], 40, 10 + 50 * i, 500, 50);
			for (int i = 0; i <= N; i++)
					g.DrawLine(BlackPen, 40, 10 + 50 * i, 40 + 500, 10 + 50 * i);
			g.DrawLine(BlackPen, 40, 10, 40, 10 + 50 * (N));
			g.DrawLine(RedPen, 40 + 500, 10, 40 + 500, 10 + 50 * (N));
			
		}
		public void SetCockroach(int N, Graphics g)
		{
			for (int i = 0; i < N; i++)
					cockroach[i] = new Cockroach(40, 35 + 50 * i, br[i]);
			DrawCockroaches(N, g);
		}
		public void DrawCockroaches(int N, Graphics g)
		{
			Image fon = Image.FromFile(@"C:\Users\dasha\Documents\3 семак\ООП\Cockroach_Race\cockr.jpg");
			for (int i = 0; i < N; i++)
				g.DrawImage(fon, cockroach[i].X, cockroach[i].Y);
			//g.FillRectangle(br[i], cockroach[i].X - cockroach[i].raduis, cockroach[i].Y - cockroach[i].raduis, cockroach[i].raduis * 2, cockroach[i].raduis * 2);
		}
		public void timer_Tick(object sender, EventArgs e)
		{
			string s = "";
			pictureBox1.Refresh();
			for (int i = 0; i < N; i++)
				if (cockroach[i].X < 40 + 500)
					cockroach[i].Move();
			TimerBox.Text = "Race time " + (DateTime.Now - PlaceAndTime.StartTime).ToString();
			if (PlaceAndTime.place == N)
			{
				timer.Stop();
				for (int i = 0; i < N; i++)
				{
					s += "Таракашка " + (i + 1).ToString() + " финишировал " + cockroach[i].place + "\n Его время: " + cockroach[i].FinishTime.ToString() + Environment.NewLine;
				}							
				label_result.Text = s;           	  
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (timer.Enabled)
			{
				DrawField(N, e.Graphics);
				DrawCockroaches(N, e.Graphics);
			}
		}
	}
}
