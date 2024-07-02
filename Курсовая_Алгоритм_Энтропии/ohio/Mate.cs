using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohio
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

        public double h(double min, double max, int l)
        {

        }
    }
}
