using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class Matrix
    {
       
        int[,] array_matrix;
        int Width = 3;
        int Height = 3;
        private Matrix matrix;

        public Matrix() { }

        public Matrix(Matrix matrix)
        {
            this.matrix = matrix;
        }

        public Matrix(int Width, int Height)
        {
            array_matrix = new int[Width, Height];
            int Length = Width * Height;
        }

        public int this[int i, int j] // индексатор для массива
        {
            get { return array_matrix[i,j]; }
            set { array_matrix[i,j] = value; }
        }
        
        public void Print()
        {
            var rand = new Random();
            if (array_matrix != null)
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        array_matrix[i, j] = rand.Next(1, 10);
                        Console.Write(array_matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }

            
        }
        public static Matrix operator *(Matrix array_matrix1, Matrix array_matrix2)
        {
            Console.WriteLine($"Результат перемножения матриц: ");
            Matrix array_matrix3 = new Matrix(3, 3);

            for (int i = 0; i < 3; i++) // заполнение новой матрицы умножением двух матриц
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        array_matrix3[i, j] += array_matrix1[i, k] * array_matrix2[k, j];
                    }
                }
            }
            return array_matrix3;
        }

        public static Vector operator *(Matrix array_matrix1, Vector vector1)
        {
            Console.WriteLine($"Результат умножения вектора-столбца на первую матрицу: ");
            Vector vector2 = new Vector(3);
            int[,] column_vector = new int[3, 1]; // вектор-столбец должен быть равен кол-ву строк в массиве
            for (int i = 0; 3 > i; i++)
            {
                for (int j = 0; 1 > j; j++)
                {
                    column_vector[i, j] = vector1[i]; 
                }
            }
            int dop_peremen = 0;
            for (int i = 0; 3 > i; i++) // умножаем все элементы массива на соотвуствующий элемент из вектора-столбца
            {
                for (int j = 0; 3 > j; j++)
                {
                    array_matrix1[i, j] *= column_vector[dop_peremen, 0];
                    dop_peremen++;
                }
                dop_peremen = 0;
            }
            int sum_str = 0;
            
            for (int i = 0; 3 > i; i++) // находим сумму умноженных элементов в строке и записываем в новый массив
            {
                for (int j = 0; 3 > j; j++)
                {
                    sum_str += array_matrix1[i, j];
                }
                vector2[i] = sum_str;
                sum_str = 0;
            }

            return vector2;
        }

        public void Print_ym()
        {
            var rand = new Random();
            if (array_matrix != null)
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                     
                        Console.Write(array_matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }

        }
    }
}
