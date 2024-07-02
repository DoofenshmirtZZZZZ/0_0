using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_Sierpinski
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			textBox1.Text = "5";
		}


		private void Draw(int level, PointF top_point, PointF left_point, PointF right_point)
		{
			if (level == 0)
			{
				// Заполните треугольник.
				PointF[] points =
				{
					top_point, right_point, left_point
				};
				g_2.FillPolygon(Brushes.Red, points);
			}
			else
			{
				// Найти граничные точки.
				PointF left_mid = new PointF(
					(top_point.X + left_point.X) / 2f,
					(top_point.Y + left_point.Y) / 2f);
				PointF right_mid = new PointF(
					(top_point.X + right_point.X) / 2f,
					(top_point.Y + right_point.Y) / 2f);
				PointF bottom_mid = new PointF(
					(left_point.X + right_point.X) / 2f,
					(left_point.Y + right_point.Y) / 2f);

				// Рекурсивно рисуем меньшие треугольники.
				Draw(level - 1, top_point, left_mid, right_mid);
				Draw(level - 1, left_mid, left_point, bottom_mid);
				Draw(level - 1, right_mid, bottom_mid, right_point);
			}
		}

		private void DrawRectangle(int level, RectangleF rect)
		{
		   
			if (level == 0)
			{
				// Заполн прямоугольник.
				g_2.FillRectangle(Brushes.Blue, rect);
			}
			else
			{
				// Разделим прямоугольник на 9 частей.
				float wid = rect.Width / 3f;
				float x0 = rect.Left;
				float x1 = x0 + wid;
				float x2 = x0 + wid * 2f;

				float hgt = rect.Height / 3f;
				float y0 = rect.Top;
				float y1 = y0 + hgt;
				float y2 = y0 + hgt * 2f;

				// Рекурсивно рисуем меньшие ковры.
				DrawRectangle(level - 1, new RectangleF(x0, y0, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x1, y0, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x2, y0, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x0, y1, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x2, y1, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x0, y2, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x1, y2, wid, hgt));
				DrawRectangle(level - 1, new RectangleF(x2, y2, wid, hgt));
			}
		}

		private Graphics g_2;

		private void button1_Click(object sender, EventArgs e)
		{
			g_2 = pictureBox1.CreateGraphics();
			g_2.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
			PointF top_point = new Point(175, 50);
			PointF left_point = new Point(50, 250);
			PointF right_point = new Point(300, 250);

			int lvl = Convert.ToInt32(textBox1.Text);

			Draw(lvl,top_point, left_point, right_point);
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			g_2 = pictureBox1.CreateGraphics();
			g_2.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

			RectangleF rect = new Rectangle(50, 50, 200, 200);

			int lvl = Convert.ToInt32(textBox1.Text);

			DrawRectangle(lvl, rect);

		}
	}
}
