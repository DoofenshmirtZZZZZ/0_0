using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohio
{
    class Obj_Mate
    {
		public string[] set_1 { get; set; }
		public string[] set_2 { get; set; }
		public double min { get; set; }
		public double max { get; set; }

		public double[] All_Things()
		{
			int k = 0;
			double[] SET_ALL = new double[set_1.Length + set_2.Length];
			for (int i = 0; SET_ALL.Length > i; i++)
			{
				if (i < set_1.Length)
				{
					SET_ALL[i] = Convert.ToDouble(set_1[i]);
				}
				else
				{

					SET_ALL[i] = Convert.ToDouble(set_2[k]);
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
	}
}
