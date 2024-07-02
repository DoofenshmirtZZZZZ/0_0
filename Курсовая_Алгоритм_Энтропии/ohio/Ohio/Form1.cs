using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

using OfficeOpenXml;

namespace Ohio
{
	public partial class Form1 : Form
	{
		private static Random rand = new Random();
		int chek = 0;

		public Form1()
		{

			InitializeComponent();
			
			numericUpDown1.Value = 3;
			comboBox1.DisplayMember = "Name";
			textBox1.Text = "1";
			textBox2.Text = "2";
			textBox3.Text = "26";

			textBox4.Text = "3";
			textBox5.Text = "2";
			textBox6.Text = "26";

			textBox7.Text = "5";
			textBox8.Text = "2";
			textBox9.Text = "5";

			textBox10.Text = "25";
			textBox11.Text = "10";
			textBox12.Text = "100";
			textBox13.Text = "1000";
			textBox21.Text = "2000";

			textBox17.Text = "25";
			textBox16.Text = "10";
			textBox15.Text = "100";
			textBox14.Text = "1000";
			textBox133.Text = "2000";

			textBox24.Text = "5";
			textBox23.Text = "10";
			textBox20.Text = "100";
			textBox19.Text = "1000";
			textBox18.Text = "2000";

		}

		private void button1_Click(object sender, EventArgs e)
		{
			// ПОДГРУЖАЕМ ДАННЫЕ ИЗ ЭКСЕЛИ 

			OpenFileDialog opf = new OpenFileDialog();
			opf.Filter = "Файл Excel|*.XLSX;*.XLS";
			opf.ShowDialog();
			System.Data.DataTable tb = new System.Data.DataTable();
			string filename = opf.FileName;

			Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
			Microsoft.Office.Interop.Excel._Workbook ExcelWorkBook;
			Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;

			ExcelWorkBook = ExcelApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
			ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

			string[] x_1 = new string[Convert.ToInt32(textBox3.Text)];
			string[] y_1 = new string[Convert.ToInt32(textBox6.Text)];
			string[] x_2 = new string[Convert.ToInt32(textBox3.Text)];
			string[] y_2 = new string[Convert.ToInt32(textBox6.Text)];
			string[] x_ex = new string[Convert.ToInt32(textBox9.Text)];
			string[] y_ex = new string[Convert.ToInt32(textBox9.Text)];

				// первый образ
			int stolb_1 = Convert.ToInt32(textBox1.Text);
			int strok_1 = Convert.ToInt32(textBox2.Text)-1;
			int count_1 = Convert.ToInt32(textBox3.Text);
			label1.Text = $"Объектов 1:{count_1} ";

				// первый образ
			int stolb_2 = Convert.ToInt32(textBox4.Text);
			int strok_2 = Convert.ToInt32(textBox5.Text)-1;
			int count_2 = Convert.ToInt32(textBox6.Text);
			label2.Text = $"Объектов 2:{count_2} ";

				// МЕ образ
			int stolb_3 = Convert.ToInt32(textBox7.Text);
			int strok_3 = Convert.ToInt32(textBox8.Text) - 1;
			int count_3 = Convert.ToInt32(textBox9.Text);
			label3.Text = $"Объектов МЭ:{count_3} ";

			int max_count = Math.Max(count_1, count_2);
			
			for (int i = 0; i < max_count; i++)
			{
				da.Rows.Add(i + 1);

			}
			for (int k = stolb_1; k < stolb_1+2; k++)
			{
				for (int i = strok_1; i < (strok_1 + count_1); i++)
				{
					da.Rows[i-strok_1].Cells[k-stolb_1].Value = ExcelApp.Cells[i + 1, k].Value;
					if (k == stolb_1)
					{
						x_1[i - strok_1] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
					else
					{
						y_1[i - strok_1] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
						
				}
			}
			for (int k = stolb_2; k < stolb_2 + 2; k++)
			{
				for (int i = strok_2; i < (strok_2 + count_2); i++)
				{
					da.Rows[i - strok_2].Cells[k-1].Value = ExcelApp.Cells[i + 1, k].Value;
					if (k == stolb_2)
					{
						x_2[i - strok_2] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
					else
					{
						y_2[i - strok_2] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
				}
			}
			for (int k = stolb_3; k < stolb_3 + 2; k++)
			{
				for (int i = strok_3; i < (strok_3 + count_3); i++)
				{
					da.Rows[i - strok_3].Cells[k - 1].Value = ExcelApp.Cells[i + 1, k].Value;
					if (k == stolb_3)
					{
						x_ex[i - strok_3] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
					else
					{
						y_ex[i - strok_3] = Convert.ToString(ExcelApp.Cells[i + 1, k].Value);
					}
				}
			}

			// СТРОИМ ГРАФИК

			double x1;
			double x2;
			double xe;
			double y1;
			double y2;
			double ye;
			this.chart1.Series[0].Points.Clear();
			this.chart1.Series[1].Points.Clear();
			this.chart1.Series[2].Points.Clear();
			for (int i = 0; i < x_1.Length; i++)
			{
				x1 = Convert.ToDouble(x_1[i]);
				x2 = Convert.ToDouble(x_2[i]);
				y1 = Convert.ToDouble(y_1[i]);
				y2 = Convert.ToDouble(y_2[i]);
				this.chart1.Series[0].Points.AddXY(x1, y1);
				this.chart1.Series[1].Points.AddXY(x2, y2);
			}
			for (int i = 0; i < x_ex.Length; i++)
			{
				xe = Convert.ToDouble(x_ex[i]);
				ye = Convert.ToDouble(y_ex[i]);
				this.chart1.Series[2].Points.AddXY(xe, ye);
			}

			// ПРОИЗВОДИМ ВСЕ РАСЧЕТЫ
			
			Obj_Mate Mera_Shod_1 = new Obj_Mate(); // мЕРА СХОД 1
			double[] Set_1 = Mera_Shod_1.Set_Plus_Set_XY(x_1, x_2);
			double Ek_1 = Mera_Shod_1.Ek(Set_1);
			double[,] MeraS_x = Mera_Shod_1.Matrix_MS(Ek_1, Set_1);
			label8.Text = $"Разность: {Ek_1}";

			Obj_Mate Mera_Shod_2 = new Obj_Mate(); // мЕРА СХОД 2
			Mera_Shod_2.set_1 = y_1;
			Mera_Shod_2.set_2 = y_2;
			double[] Set_2 = Mera_Shod_2.Set_Plus_Set_XY(y_1, y_2);
			double Ek_2 = Mera_Shod_2.Ek(Set_2);
			double[,] MeraS_y = Mera_Shod_2.Matrix_MS(Ek_2, Set_2);
			label9.Text = $"Разность: {Ek_2}";

			Mate Mera_Shod_All = new Mate(); // мЕРА СХОД общая
			double[,] matrix_all = Mera_Shod_All.Matrix_BIG(MeraS_x, MeraS_y, Set_1, Set_2);

			for (int k = 0; Set_2.Length > k; k++)
			{
				dataGridView3.Rows.Add(MeraS_x[k, 0], MeraS_y[k, 0], matrix_all[k, 0]);
			} // выводим матрицы мкрСходства в таблицу на экран

			double min = Mera_Shod_All.Min_Matrix(matrix_all, Set_1, Set_2); // Ищем наш шаг через мин макс и задаем количество колец
			double max = Mera_Shod_All.Max_Matrix(matrix_all, Set_1, Set_2);
			label12.Text = $"MIN: {min}";
			label13.Text = $"MAX: {max}";
			label10.Text = $"Разность: {max - min}";
			int l = Convert.ToInt32(numericUpDown1.Value);
			double h = (max - min) / (l);
			label11.Text = $"h: {h}";

			Obj_Mate Mera_Shod_MEx = new Obj_Mate(); // строим меруСход с 1-МЭ
			Mera_Shod_MEx.setd_1 = Set_1;
			Mera_Shod_MEx.set_3 = x_ex;
			double[] Set_Ex_1 = Mera_Shod_MEx.Set_Plus_Set_EX();
			double Ek_ex = Mera_Shod_MEx.Ek(Set_Ex_1);
			double[,] MeraS_Ex = Mera_Shod_MEx.Matrix_ME(Ek_ex, Set_1, x_ex);

			Obj_Mate Mera_Shod_MEy = new Obj_Mate(); // строим меруСход с 2-МЭ
			Mera_Shod_MEy.setd_2 = Set_2;
			Mera_Shod_MEy.set_4 = y_ex;
			double[] Set_Ex_2 = Mera_Shod_MEy.Set_Plus_Set_EY();
			double Ek_ey = Mera_Shod_MEy.Ek(Set_Ex_2);
			double[,] MeraS_Ey = Mera_Shod_MEy.Matrix_ME(Ek_ey, Set_2, y_ex);

			Mate Mera_Shod_Big = new Mate(); // мЕРА СХОД общая
			double[,] matrix_MS_Big = Mera_Shod_Big.Matrix_BIG_ex(MeraS_Ex, MeraS_Ey, Set_1, x_ex);

			Mate Entropy = new Mate();
			double[,] matrix_entropy = new double[x_ex.Length, l];
			matrix_entropy = Entropy.GetMatrixEntropy(matrix_MS_Big, l, h, x_ex, Set_1, max);
			double[,] matrix_10 = new double[Set_1.Length, l];
			
			
			matrix_10 = Entropy.GetForTable(matrix_MS_Big, l, h, x_ex, Set_1, max, chek);

			comboBox1.DataSource = x_ex;

			DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[l];
			for (int k = 0; l > k; k++)
			{
				column[k] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
				column[k].HeaderText = $"L ={k+1} ";
				column[k].Name = "Header" + k+1;
			}
			this.dataGridView1.Columns.AddRange(column);
			for (int i = 0; Set_2.Length > i; i++)
			{
				dataGridView1.Rows.Add(i + 1);
			}
			for (int k = 0; l > k; k++)
            {
				for (int i = 0; Set_2.Length > i; i++)
                {
					dataGridView1.Rows[i].Cells[k].Value = matrix_10[i, k];
				}
			}
			string[] pus = new string[x_ex.Length];
			pus = Entropy.Get(matrix_MS_Big, matrix_entropy, x_ex, l, Set_1, max, h);
			for (int k = 0; x_ex.Length > k; k++)
			{
				dataGridView2.Rows.Add($"{k+1} - {x_ex[k]},{y_ex[k]}",$"{pus[k]}");
			}

			// ВЫВОДИМ МАТРИЦУ И ОТВЕТ НА ЭКРАН

			
			pus = Entropy.GetAnsver(matrix_MS_Big, matrix_entropy, x_ex, l, Set_1, max, h);

			for (int i = 0; i < x_ex.Length; i++)
			{
				dataGridView5.Rows.Add(i + 1, pus[i]);
			}
		} // кнопка для расчетов по эксель

		private void button2_Click_1(object sender, EventArgs e)
		{
			
			dataGridView3.Rows.Clear();
			dataGridView1.Rows.Clear();
			dataGridView2.Rows.Clear();
			da.Rows.Clear();
			dataGridView5.Rows.Clear();
			button1.PerformClick();
		} // кнопка обнов эксель

		private void button3_Click(object sender, EventArgs e)
		{

			string[] x_1 = new string[Convert.ToInt32(textBox10.Text)];
			string[] y_1 = new string[Convert.ToInt32(textBox17.Text)];
			string[] x_2 = new string[Convert.ToInt32(textBox10.Text)];
			string[] y_2 = new string[Convert.ToInt32(textBox17.Text)];
			string[] x_ex = new string[Convert.ToInt32(textBox24.Text)];
			string[] y_ex = new string[Convert.ToInt32(textBox24.Text)];
			double sigma = 0.0;
			double center = 0.0;

			for (int i = 0; i < x_1.Length; i++)
			{
				center = (rand.Next(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text)));
				sigma = center * 0.1;
				x_1[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
				center = (rand.Next(Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox21.Text)));
				sigma = center * 0.1;
				y_1[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
			}

			for (int i = 0; i < x_2.Length; i++)
			{
				center = (rand.Next(Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox15.Text)));
				sigma = center * 0.1;
				x_2[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
				center = (rand.Next(Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox133.Text)));
				sigma = center * 0.1;
				y_2[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
			}

			for (int i = 0; i < x_ex.Length; i++)
			{
				center = (rand.Next(Convert.ToInt32(textBox23.Text), Convert.ToInt32(textBox20.Text)));
				sigma = center * 0.1;
				x_ex[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
				center = (rand.Next(Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox18.Text)));
				sigma = center * 0.1;
				y_ex[i] = Convert.ToString(center + sigma * (rand.NextDouble() + rand.NextDouble() + rand.NextDouble() + rand.NextDouble() - 2) / 2);
			}

			for (int i = 0; i < x_1.Length; i++)
			{
				da.Rows.Add(i + 1);

			}
			for (int k = 1; k < 1 + 2; k++)
			{
				for (int i = 0; i < (x_1.Length); i++)
				{
					if (k == 1)
					{
						da.Rows[i].Cells[k - 1].Value = x_1[i];
					}
					else
					{
						da.Rows[i].Cells[k - 1].Value = y_1[i];
					}
					

				}
			}
			for (int k = 3; k < 3 + 2; k++)
			{
				for (int i = 0; i < (x_2.Length); i++)
				{
					if (k == 3)
					{
						da.Rows[i].Cells[k - 1].Value = x_2[i];
					}
					else
					{
						da.Rows[i].Cells[k - 1].Value = y_2[i];
					}
					
					
				}
			}
			for (int k = 5; k < 5 + 2; k++)
			{
				for (int i = 0; i < (x_ex.Length); i++)
				{
					if (k == 5)
					{
						da.Rows[i].Cells[k - 1].Value = x_ex[i];
					}
					else
					{
						da.Rows[i].Cells[k - 1].Value = y_ex[i];
					}
					
				}
			}
			label1.Text = $"Объектов 1:{x_1.Length} ";
			label2.Text = $"Объектов 2:{x_2.Length} ";
			label3.Text = $"Объектов МЭ:{x_ex.Length} ";

			double x1;
			double x2;
			double xe;
			double y1;
			double y2;
			double ye;
			this.chart1.Series[0].Points.Clear();
			this.chart1.Series[1].Points.Clear();
			this.chart1.Series[2].Points.Clear();
			for (int i = 0; i < x_1.Length; i++)
			{
				x1 = Convert.ToDouble(x_1[i]);
				x2 = Convert.ToDouble(x_2[i]);
				y1 = Convert.ToDouble(y_1[i]);
				y2 = Convert.ToDouble(y_2[i]);
				this.chart1.Series[0].Points.AddXY(x1, y1);
				this.chart1.Series[1].Points.AddXY(x2, y2);
			}

			for (int i = 0; i < x_ex.Length; i++)
			{
				xe = Convert.ToDouble(x_ex[i]);
				ye = Convert.ToDouble(y_ex[i]);
				this.chart1.Series[2].Points.AddXY(xe, ye);
			}
			//button_Dop_Click(x_1, x_2, y_1, y_2, x_ex, y_ex);



			Obj_Mate Mera_Shod_1 = new Obj_Mate(); // мЕРА СХОД 1
												   //Mera_Shod_1.set_1 = x_1;
												   //Mera_Shod_1.set_2 = x_2;
			double[] Set_1 = Mera_Shod_1.Set_Plus_Set_XY(x_1, x_2);
			double Ek_1 = Mera_Shod_1.Ek(Set_1);
			double[,] MeraS_x = Mera_Shod_1.Matrix_MS(Ek_1, Set_1);
			label8.Text = $"Разность: {Ek_1}";

			Obj_Mate Mera_Shod_2 = new Obj_Mate(); // мЕРА СХОД 2
			Mera_Shod_2.set_1 = y_1;
			Mera_Shod_2.set_2 = y_2;
			double[] Set_2 = Mera_Shod_2.Set_Plus_Set_XY(y_1, y_2);
			double Ek_2 = Mera_Shod_2.Ek(Set_2);
			double[,] MeraS_y = Mera_Shod_2.Matrix_MS(Ek_2, Set_2);
			label9.Text = $"Разность: {Ek_2}";

			Mate Mera_Shod_All = new Mate(); // мЕРА СХОД общая
			double[,] matrix_all = Mera_Shod_All.Matrix_BIG(MeraS_x, MeraS_y, Set_1, Set_2);

			for (int k = 0; Set_2.Length > k; k++)
			{
				dataGridView3.Rows.Add(MeraS_x[k, 0], MeraS_y[k, 0], matrix_all[k, 0]);
			} // выводим матрицы мкрСходства в таблицу на экран

			double min = Mera_Shod_All.Min_Matrix(matrix_all, Set_1, Set_2); // Ищем наш шаг через мин макс и задаем количество колец
			double max = Mera_Shod_All.Max_Matrix(matrix_all, Set_1, Set_2);
			label12.Text = $"MIN: {min}";
			label13.Text = $"MAX: {max}";
			label10.Text = $"Разность: {max - min}";
			int l = Convert.ToInt32(numericUpDown1.Value);
			double h = (max - min) / (l);
			label11.Text = $"h: {h}";

			Obj_Mate Mera_Shod_MEx = new Obj_Mate(); // строим меруСход с 1-МЭ
			Mera_Shod_MEx.setd_1 = Set_1;
			Mera_Shod_MEx.set_3 = x_ex;
			double[] Set_Ex_1 = Mera_Shod_MEx.Set_Plus_Set_EX();
			double Ek_ex = Mera_Shod_MEx.Ek(Set_Ex_1);
			double[,] MeraS_Ex = Mera_Shod_MEx.Matrix_ME(Ek_ex, Set_1, x_ex);


			Obj_Mate Mera_Shod_MEy = new Obj_Mate(); // строим меруСход с 2-МЭ
			Mera_Shod_MEy.setd_2 = Set_2;
			Mera_Shod_MEy.set_4 = y_ex;
			double[] Set_Ex_2 = Mera_Shod_MEy.Set_Plus_Set_EY();
			double Ek_ey = Mera_Shod_MEy.Ek(Set_Ex_2);
			double[,] MeraS_Ey = Mera_Shod_MEy.Matrix_ME(Ek_ey, Set_2, y_ex);

			Mate Mera_Shod_Big = new Mate(); // мЕРА СХОД общая
			double[,] matrix_MS_Big = Mera_Shod_Big.Matrix_BIG_ex(MeraS_Ex, MeraS_Ey, Set_1, x_ex);

			Mate Entropy = new Mate();
			double[,] matrix_entropy = new double[x_ex.Length, l];
			matrix_entropy = Entropy.GetMatrixEntropy(matrix_MS_Big, l, h, x_ex, Set_1, max);

			double[,] matrix_10 = new double[Set_1.Length, l];


			matrix_10 = Entropy.GetForTable(matrix_MS_Big, l, h, x_ex, Set_1, max, chek);

			comboBox1.DataSource = x_ex;

			DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[l];
			for (int k = 0; l > k; k++)
			{
				column[k] = new DataGridViewTextBoxColumn(); // выделяем память для объекта
				column[k].HeaderText = $"L ={k + 1} ";
				column[k].Name = "Header" + k + 1;
			}
			this.dataGridView1.Columns.AddRange(column);
			for (int i = 0; Set_2.Length > i; i++)
			{
				dataGridView1.Rows.Add(i + 1);
			}
			for (int k = 0; l > k; k++)
			{
				for (int i = 0; Set_2.Length > i; i++)
				{
					dataGridView1.Rows[i].Cells[k].Value = matrix_10[i, k];
				}
			}
			string[] pus = new string[x_ex.Length];
			pus = Entropy.Get(matrix_MS_Big, matrix_entropy, x_ex, l, Set_1, max, h);
			for (int k = 0; x_ex.Length > k; k++)
			{
				dataGridView2.Rows.Add($"{k + 1} - {x_ex[k]},{y_ex[k]}", $"{pus[k]}");
			}

			pus = Entropy.GetAnsver(matrix_MS_Big, matrix_entropy, x_ex, l, Set_1, max, h);


			for (int i = 0; i < x_ex.Length; i++)
			{
				dataGridView5.Rows.Add(i + 1, pus[i]);
			}

		} // кнопка по генерации

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			chek = comboBox1.SelectedIndex;
		

		}

        private void button4_Click(object sender, EventArgs e)
        {
			dataGridView3.Rows.Clear();
			dataGridView1.Rows.Clear();
			dataGridView2.Rows.Clear();
			da.Rows.Clear();
			dataGridView5.Rows.Clear();
			button3.PerformClick();

		} // кнопка по обнов генерации

        private void button5_Click(object sender, EventArgs e)
        {
			chek = comboBox1.SelectedIndex;
			button1.PerformClick();
		}
    }
	
}
