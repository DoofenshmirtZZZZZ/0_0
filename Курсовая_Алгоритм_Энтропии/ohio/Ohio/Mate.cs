using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohio
{
	class Mate
	{
		public double[] set { get; set; }

		public double[,] Matrix_BIG(double[,] set_1, double[,] set_2, double[] Set, double[] Set_2)
		{
			double[,] matrix = new double[Set.Length, Set_2.Length];

			for (int i = 0; Set.Length > i; i++)
			{
				for (int j = 0; Set_2.Length > j; j++)
				{
					matrix[i, j] = set_1[i, j] * 0.5 + set_2[i, j] * 0.5;
				}

			} // общая матрица мер сходства

			return matrix;
		}

		public double[,] Matrix_BIG_ex(double[,] set_1, double[,] set_2, double[] Set, string[] Set_2)
		{
			double[,] matrix = new double[Set.Length, Set_2.Length];

			for (int i = 0; Set.Length > i; i++)
			{
				for (int j = 0; Set_2.Length > j; j++)
				{
					matrix[i, j] = set_1[i, j] * 0.5 + set_2[i, j] * 0.5;
				}

			} 

			return matrix;
		}

		public double Min_Matrix(double[,] set, double[] Set_1, double[] Set_2)
		{
			double min = 2;
			for (int i = 0; Set_1.Length > i; i++)
			{
				for (int j = 0; Set_2.Length > j; j++)
				{
					if (min > set[i, j])
					{
						min = set[i, j];
					}
				}

			}
			return min;
		}

		public double Max_Matrix(double[,] set, double[] Set_1, double[] Set_2)
		{
			double max = 0;
			for (int i = 0; Set_1.Length > i; i++)
			{
				for (int j = 0; Set_2.Length > j; j++)
				{
					if ((max < set[i, j]) && (i != j))
					{
						max = set[i, j];
					}
				}

			}
			return max;
		}
		public string[] GetAnsver(double[,] matrix_ms, double[,] matrix_entropy, string[] ex, int l, double[] set, double max, double h)
        {
			string[] ansver = new string[ex.Length];
			double min = 5;
			int sfer = 0;  

			for (int k = 0; ex.Length > k; k++)
            {
				for (int pop = 0; l > pop; pop++)
                {
					if(min > matrix_entropy[k, pop])
                    {
						min = matrix_entropy[k, pop];
						sfer = pop;
					}
                }

				double[] time_ex = new double[(set.Length)];
				for (int i = 0; (set.Length) > i; i++)
				{
					time_ex[i] = matrix_ms[i, k];
				}
				int count1 = 0;
				int count2 = 0;
				// нашли минимум теперь надо его сравнить
				for (int i = 0; (set.Length) > i; i++)
				{
					if (time_ex[i] >= (max - ((sfer+1) * h)))
					{
						if (i > ((set.Length)/2))
						{
							count2++;
						}
						else count1++;
					}
				}
				// теперь проверяем к какому образу

				double Nr1 = count1;
				double Nr2 = count2;
				double Nr = Nr1 + Nr2;
				double N1 = (set.Length)/2;
				double N2 = (set.Length)/2;
				double N = (set.Length);

				double mom1 = (N1 / N) * (Nr1 / Nr);
				double mom2 = (N2 / N) * (Nr2 / Nr);

				if (mom1 >= mom2)
				{
					ansver[k] = $"1 обр";
				}
				else ansver[k] = $"2 обр";
			}
			return ansver;

		}
		public double[,] GetMatrixEntropy(double[,] matrix_ms, int l, double h, string[] ex, double[] set, double max)
		{
			
			double[,] matrix_entropy = new double[ex.Length, l];

			int count1 = 0;
			int count2 = 0;
			double Hr = 0;

			for (int k = 0; ex.Length > k; k++)
			{
				double[] time_ex = new double[(set.Length)];
				for (int i = 0; (set.Length) > i; i++)
				{
					time_ex[i] = matrix_ms[i, k];
				}


				for (int pop = 0; l > pop; pop++)
				{
					for (int i = 0; (set.Length) > i; i++)
					{
						if (time_ex[i] >= (max - ((pop+1) * h)))
						{
							if(i> (set.Length/2))
							{
								count2++;
							}	
							else count1++;
						}
					}
					double Hr1 = (((double)count1 / (double)(set.Length)) * Math.Log10((double)count1 / (double)(set.Length)));
					double Hr2 = (((double)count2 / (double)(set.Length)) * Math.Log10((double)count2 / (double)(set.Length)));
					Hr = -(Hr1+Hr2);
					matrix_entropy[k, pop] = Hr;
					count1 = 0;
					count2 = 0;
				}
			}
			return matrix_entropy;
		}
		public double[,] GetForTable(double[,] matrix_ms, int l, double h, string[] ex, double[] set, double max, int chek)
		{

			double[,] matrix_10 = new double[set.Length, l];
			double[] time_ex = new double[(set.Length)];
			for (int i = 0; (set.Length) > i; i++)
			{
				time_ex[i] = matrix_ms[i, chek];
			}


			for (int pop = 0; l > pop; pop++)
			{
				for (int i = 0; (set.Length) > i; i++)
				{
					if (time_ex[i] >= (max - ((pop + 1) * h)))
					{
						matrix_10[i, pop] = 1;
						
					}
					else matrix_10[i, pop] = 0;
				}

			}





			return matrix_10;
		}

		public string[] Get(double[,] matrix_ms, double[,] matrix_entropy, string[] ex, int l, double[] set, double max, double h)
		{
			string[] ansver = new string[ex.Length];
			double min = 5;
			int sfer = 0;

			for (int k = 0; ex.Length > k; k++)
			{
				for (int pop = 0; l > pop; pop++)
				{
					if (min > matrix_entropy[k, pop])
					{
						min = matrix_entropy[k, pop];
						sfer = pop;
					}
				}

				double[] time_ex = new double[(set.Length)];
				for (int i = 0; (set.Length) > i; i++)
				{
					time_ex[i] = matrix_ms[i, k];
				}
				int count1 = 0;
				int count2 = 0;
				// нашли минимум теперь надо его сравнить
				for (int i = 0; (set.Length) > i; i++)
				{
					if (time_ex[i] >= (max - ((sfer + 1) * h)))
					{
						if (i > ((set.Length) / 2))
						{
							count2++;
						}
						else count1++;
					}
				}
				// теперь проверяем к какому образу

				double Nr1 = count1;
				double Nr2 = count2;
				double Nr = Nr1 + Nr2;
				double N1 = (set.Length) / 2;
				double N2 = (set.Length) / 2;
				double N = (set.Length);

				double mom1 = (N1 / N) * (Nr1 / Nr);
				double mom2 = (N2 / N) * (Nr2 / Nr);

				ansver[k] = $"{Math.Round(mom1,4)} и {Math.Round(mom2,4)}";
				
			}
			return ansver;

		}
	}
}
