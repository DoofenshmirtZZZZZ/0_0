using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohio
{
    class Obj_Mate
    {
		public string[] set_1 { get; set; }
		public string[] set_2 { get; set; }
		public string[] set_3 { get; set; }
		public string[] set_4 { get; set; }

		public double[] setd_1 { get; set; }
		public double[] setd_2 { get; set; }
		public double min { get; set; }
		public double max { get; set; }

		public double[] Set_Plus_Set_XY(string[] x_1, string[] x_2)
		{
			int k = 0;
			double[] SET_ALL = new double[x_1.Length + x_2.Length];
			for (int i = 0; SET_ALL.Length > i; i++)
			{
				if (i < x_1.Length)
				{
					SET_ALL[i] = Convert.ToDouble(x_1[i]);
				}
				else
				{

					SET_ALL[i] = Convert.ToDouble(x_2[k]);
					k++;

				}


			}

			return SET_ALL;
		}

		public double[] Set_Plus_Set_EX()
		{
			int k = 0;
			double[] SET_ALL = new double[setd_1.Length + set_3.Length];
			for (int i = 0; SET_ALL.Length > i; i++)
			{
				if (i < setd_1.Length)
				{
					SET_ALL[i] = Convert.ToDouble(setd_1[i]);
				}
				else
				{

					SET_ALL[i] = Convert.ToDouble(set_3[k]);
					k++;

				}


			}

			return SET_ALL;
		}

		public double[] Set_Plus_Set_EY()
		{
			int k = 0;
			double[] SET_ALL = new double[setd_2.Length + set_4.Length];
			for (int i = 0; SET_ALL.Length > i; i++)
			{
				if (i < setd_2.Length)
				{
					SET_ALL[i] = Convert.ToDouble(setd_2[i]);
				}
				else
				{

					SET_ALL[i] = Convert.ToDouble(set_4[k]);
					k++;

				}
			}

			return SET_ALL;
		}

		public double[,] Matrix_MS(double Ek, double[] SET)
		{

			double[,] matrix = new double[SET.Length, SET.Length];
			for (int i = 0; SET.Length > i; i++)
			{
				for (int j = 0; SET.Length > j; j++)
				{
					matrix[i, j] = 1 - (Math.Abs(Convert.ToDouble(SET[i]) - Convert.ToDouble(SET[j])) / Ek);
				}
			}
			return matrix;
		} // метод для расчета матрицы мер сходства
		public double Ek(double[] Set)
		{
			double min = 1000000000;
			double max = 0;
			for (int i = 0; Set.Length > i; i++)
			{

				if (Set[i] < min)
				{
					min = Set[i];
				}
				if (Set[i] > max)
				{
					max = Set[i];
				}
			}
			double Ek = Math.Abs(max - min);
			return Ek;
		} // метод для расчета разности

		public double[,] Matrix_ME(double Ek, double[] SET_MO, string[] SET_ME)
		{
			double[,] matrix = new double[SET_MO.Length, SET_ME.Length];
			for (int i = 0; SET_MO.Length > i; i++)
			{
				for (int j = 0; SET_ME.Length > j; j++)
				{
					matrix[i, j] = 1 - ((Math.Abs(SET_MO[i] - Convert.ToDouble(SET_ME[j]))) / Ek);
				}
			}
			return matrix;
		} // метод для расчета матрицы мер сходства
	}
}
