using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
	public partial class fractals : Form
	{
		public fractals()
		{
			InitializeComponent();
			numericUpDown1.Value = 6;
			numericUpDown2.Value = 3;

			p_1 = new Pen(Color.Black);			
			s_2 = new SolidBrush(Color.Black);
			p_3 = new Pen(Color.Black);
			p_4 = new Pen(Color.Black);

			pictureBox9.BackColor = Color.Black;
			pictureBox8.BackColor = Color.Black;
			pictureBox7.BackColor = Color.Black;
			pictureBox6.BackColor = Color.Black;


		}
		
		private Graphics g_1;
		private Pen p_1;

		private void Draw_1(int x_1, int y_1, double length_1, double corner_1)
		{
			if (length_1 > 1)
			{
				g_1.DrawLine(p_1, x_1, y_1, (int)Math.Round(x_1 + length_1 * Math.Cos(corner_1)), (int)Math.Round(y_1 - length_1 * Math.Sin(corner_1)));
				x_1 = (int)Math.Round(x_1 + length_1 * Math.Cos(corner_1));
				y_1 = (int)Math.Round(y_1 - length_1 * Math.Sin(corner_1));
				Draw_1(x_1, y_1, length_1 * 0.4, corner_1 - 14 * Math.PI / 30);
				Draw_1(x_1, y_1, length_1 * 0.4, corner_1 + 14 * Math.PI / 30);
				Draw_1(x_1, y_1, length_1 * 0.7, corner_1 + Math.PI / 30);
			}
		} // Функция, которая рисует первые линии папоротника, задает новые координаты для отрисовки, вызывает саму себя для отрисовки. Причем если length_1 < 1 функция работу прекращает, так как рисунок будет сделать невозможно

		public void button1_Click(object sender, EventArgs e)
		{			
			g_1 = pictureBox1.CreateGraphics();			
			g_1.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);

			try
			{
				int x = Convert.ToInt32(x_1_unp.Text); // передвигает по оси Х
				int y = Convert.ToInt32(y_1_unp.Text); // передвигает по оси Y
				int length = Convert.ToInt32(length_1_unp.Text); // задает длину ветви папоротника 
				int corner = Convert.ToInt32(corner_1_unp.Text); // угол поворота
				Draw_1(x, y, length, corner);
			}
			catch (Exception)
			{
				Draw_1(200, 400, 100, Math.PI / 2);
			}            
				 
		} // Кнопка для отрисовки фрактала, где можно задать свои параметры, завернутые в обработку исключений

		// Лэйблы ссылки для справки в помощь пользователю
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось X лучше задать в районе 200-300, чтобы картинка была корректной");
		}
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось Y лучше задать в районе 300-400, чтобы картинка была корректной");
		}
		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Для идельной картинки подойдет 100, но соотвественно, чем больше цифра тем больше будет фрактал, учтите это");
		}
		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Для идельной картинки подойдет число возле 1,5, если число меньше 1,5 то поворот вправо, если больше то влево");
		}

		private void button52_Click(object sender, EventArgs e) 
		{
			Reference1 newForm = new Reference1();
			newForm.Show();
		} // Кнопка для вызова теоретической справки

		// _____________________________________________________________________________________________________________________

		private Graphics g_2;
		private SolidBrush s_2;
		
		int Draw_2(int x0_2, int y0_2, int r_2, int dir_2, int iter_2)
		{
			g_2.FillEllipse(s_2, x0_2 - r_2, y0_2 - r_2, 2 * r_2, 2 * r_2);
			if (iter_2 == 0)
				return 0;
			int[] x_2 = new int[4];
			int[] y_2 = new int[4];
			int d_2 = 3 * r_2 / 2;
			x_2[0] = x0_2 - d_2;
			y_2[0] = y0_2;
			x_2[1] = x0_2;
			y_2[1] = y0_2 - d_2;
			x_2[2] = x0_2 + d_2;
			y_2[2] = y0_2;
			x_2[3] = x0_2;
			y_2[3] = y0_2 + d_2;

			for (int i = 0; i < 4; i++)
			{
				if ((i - dir_2 == 2) || (i - dir_2 == -2))
					continue;				
				Draw_2(x_2[i], y_2[i], r_2 / 2, i, iter_2 - 1);				
			}
			return 0;
		} // Функция drawFractal получает в качестве параметров координаты центра круга, затем радиус, затем индекс, определяющий положение его родителя(для самого первого полагаем, что родитель был "снизу"), а также количество итераций. Рисуем круг со входными данными, далее в случае, если итераций не осталось, заканчиваем отрисовку, иначе - находим координаты всех центров потенциальных кругов-потомком, а затем для каждого, кроме того, чье место занято родителем, вызываем эту же самую функцию с соответствующими параметрами.

		private void button2_Click(object sender, EventArgs e)
		{
			g_2 = pictureBox2.CreateGraphics();
			g_2.FillRectangle(Brushes.White, 0, 0, pictureBox2.Width, pictureBox2.Height);

			try
			{
				int x = Convert.ToInt32(x_2_unp.Text); // передвигает по оси Х
				int y = Convert.ToInt32(y_2_unp.Text); // передвигает по оси Y
				int r = Convert.ToInt32(r_2_unp.Text); // задает масштаб
				int iter = Convert.ToInt32(iter_2_unp.Text); // число повторений цикла
				int dir = Convert.ToInt32(dir_2_unp.Text); // поворот фрактала
				Draw_2(x, y, r, dir, iter);
			}
			catch (Exception)
			{				
				Draw_2(300, 350, 50, 1, 10);
			}
		} // Кнопка для отрисовки фрактала, где можно задать свои параметры, завернутые в обработку исключений

		// Лэйблы ссылки для справки в помощь пользователю
		private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось X лучше задать в районе 200-300, чтобы картинка была корректной");
		}
		private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось Y лучше задать в районе 300-400, чтобы картинка была корректной");
		}
		private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Задается радиус кругов, соотвественно чем больше радиус тем больше фрактал, рекомендуется задавать значение от 50,  чтобы картинка была корректной");
		}
		private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Число повторов построения. Не рекомендуется ставить выше 16, иначе программа может зависнуть");
		}
		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Число поворотов построения. Если ставить выше 5 то фрактал закручивается");
		}

		private void button53_Click(object sender, EventArgs e)
		{
			Reference2 newForm = new Reference2();
			newForm.Show();
		} // Кнопка для вызова теоретической справки

		// _____________________________________________________________________________________________________________________

		private Graphics g_3;
		private Pen p_3;

		private void Draw_3(int x_3, int y_3, int size_3)
		{
			int iter_3 = (int)numericUpDown1.Value; // 6
			int a_3 = (int)numericUpDown2.Value; // 3
			int r1, r2;			

			if (size_3 > 1)
			{
				r1 = (int)Math.Round(size_3 / (a_3 * 1.0));
				r2 = (int)Math.Round(size_3 * (a_3 - 1.0) / a_3);
				Draw_3(x_3, y_3, r1);
				for (int i = 1; i <= iter_3; i++)
					Draw_3(x_3 - (int)Math.Round(r2 * Math.Sin(2 * Math.PI / iter_3 * i)), y_3 + (int)Math.Round(r2 * Math.Cos(2 * Math.PI / iter_3 * i)), r1);		
			}
			g_3.DrawEllipse(p_3, x_3 - size_3, y_3 - size_3, 2 * size_3, 2 * size_3);
		} // Функция для отрисовки кругового фрактала. Задаются параметры, причем если масштаб (size_3) меньше 1 то фрактал не нарисуется. Функция вызывает саму себя, куда передает координаты и посчитанные радиусы (r1, r2). Задается цикл отрисовки, где вызывается та же функция для отрисовки, таким образом создавая рекурсию

		private void button3_Click(object sender, EventArgs e)
		{
			g_3 = pictureBox3.CreateGraphics();			
			g_3.FillRectangle(Brushes.White, 0, 0, pictureBox3.Width, pictureBox3.Height);

			try
			{
				int x = Convert.ToInt32(x_3_unp.Text); // передвигает по оси Х
				int y = Convert.ToInt32(y_3_unp.Text); // передвигает по оси Y
				int size = Convert.ToInt32(size_3_unp.Text); // задает масштаб
				Draw_3(x, y, size);
			}
			catch (Exception)
			{
				Draw_3(300, 230, 200);
			}
		} // Кнопка для отрисовки фрактала, где можно задать свои параметры, завернутые в обработку исключений

		// Лэйблы ссылки для справки в помощь пользователю
		private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Число поворотов построения. Если ставить выше 6 то фрактал сжимается, так как увеличичвается кол-во кругов");
		}
		private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Расстояние между окружностями. Рекомендуемая величина - 3. Чем меньше значение тем больше расстояние");
		}
		private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Для идельной картинки подойдет 200, но соотвественно, чем больше цифра тем больше будет фрактал, учтите это");
		}
		private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось Y лучше задать в районе 200-300, чтобы картинка была корректной");
		}
		private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Ось X лучше задать в районе 300-400, чтобы картинка была корректной");
		}

		private void button54_Click(object sender, EventArgs e)
		{
			Reference3 newForm = new Reference3();
			newForm.Show();
		} // Кнопка для вызова теоретической справки

		// _____________________________________________________________________________________________________________________

		private Graphics g_4;
		private Pen p_4;

		void Draw_4(int x1_4, int y1_4, int x2_4, int y2_4, int n_4)
		{					
			if (n_4 > 0)
			{
				int xn = (x1_4 + x2_4) / 2 + (y2_4 - y1_4) / 2;
				int yn = (y1_4 + y2_4) / 2 - (x2_4 - x1_4) / 2;
				Draw_4(x2_4, y2_4, xn, yn, n_4 - 1);
				Draw_4(x1_4, y1_4, xn, yn, n_4 - 1);
			}

			var point1 = new Point(x1_4, y1_4);
			var point2 = new Point(x2_4, y2_4);
			g_4.DrawLine(p_4, point1, point2);
		} // Функция выдает результат при заданном кол-ве итераций (n_4) > 0. Щтрезок делим  пополам и строим из получившихся отрезков прямой угол. Затем многократно повторяем итерацию (n_4)

		private void button4_Click(object sender, EventArgs e)
		{
			g_4 = pictureBox4.CreateGraphics();			
			g_4.FillRectangle(Brushes.White, 0, 0, pictureBox4.Width, pictureBox4.Height);

			try
			{
				int x1 = Convert.ToInt32(x1_4_unp.Text); // x верхнего крюка
				int y1 = Convert.ToInt32(y1_4_unp.Text); // y верхнего крюка
				int x2 = Convert.ToInt32(x2_4_unp.Text); // x нижнего крюка
				int y2 = Convert.ToInt32(y2_4_unp.Text); // y нижнего крюка
				int k = Convert.ToInt32(k_4_unp.Text); // частота рекурсии
				Draw_4(x1, y1, x2, y2, k);
			}
			catch (Exception)
			{
				Draw_4(200, 150, 300, 390, 15);
			}
		} // Кнопка для отрисовки фрактала, где можно задать свои параметры, завернутые в обработку исключений

		// Лэйблы ссылки для справки в помощь пользователю
		private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Верхняя координата для x1 лучше задавать в районе 150-250");
		}
		private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Верхняя координата для y1 лучше задавать в районе 100-200");
		}
		private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Нижняя координата для x1 лучше задавать в районе 300-350");
		}
		private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Нижняя координата для x1 лучше задавать в районе 300-400");
		}
		private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Частота отрисовки отрезков. На автомате стоит 15. Если нужно более показательное построение то ставьте на 5");
		}

		private void button55_Click(object sender, EventArgs e)
		{
			Reference4 newForm = new Reference4();
			newForm.Show();
		} // Кнопка для вызова теоретической справки    

		// _____________________________________________________________________________________________________________________

		private void button_help_Click(object sender, EventArgs e)
		{
			MessageBox.Show("	Программа для отрисовки фракталов. В веху программы находятся вклади, переключая которые вы попадаете в окно отведенное фракталу. \n	   Справа панель, в которую можно ввести свои параметры для построения. Если поля пустые, то программа рисует фрактал по заданным автоматически данным. \n	У каждого фрактала есть своя теоретическая справка, где подробно описаны алгоритмы постороения, формулы и соответсвующие рисунки. \n	 При переходе по вкладкам их содержимое очищается, пожалуйста, помните об этом.");
		} // Кнопка помощи

		// Кнопки для выбора цвета пера
        private void button_color1_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				p_1.Color = colorDialog1.Color;
				pictureBox9.BackColor = colorDialog1.Color;
			}
		}
        private void button_color2_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				s_2.Color = colorDialog1.Color;
				pictureBox8.BackColor = colorDialog1.Color;
			}
		}
        private void button_color3_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				p_3.Color = colorDialog1.Color;
				pictureBox7.BackColor = colorDialog1.Color;
			}
		}
        private void button_color4_Click(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				p_4.Color = colorDialog1.Color;
				pictureBox6.BackColor = colorDialog1.Color;
			}
		}
    }
}

