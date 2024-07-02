using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class Vector
    {
        int[] array_vector;
        int size;
        public Vector() { }
        public Vector(int size) // конструктор с параметром (длина вектора). Этот конструктор должен создать массив Values, заданной длины
        {
            array_vector = new int[size];
        }
        public int this[int i] // индексатор
        {
            get { return array_vector[i]; }
            set { array_vector[i] = value; }
        }
        public int Size
        {
            set
            {
                if (array_vector == null)
                {
                    size = value;
                    array_vector = new int[size];
                }
            }
            get { return size; }
        }
        public void Print() // вывод векторов
        {
            var rand = new Random();
            if (array_vector != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    array_vector[i] = rand.Next(1, 10);
                    Console.Write(Convert.ToString(array_vector[i]) + "\n");
                }
                Console.WriteLine();
            }
        }

        public void Print_ym() // вывод векторов
        {
            var rand = new Random();
            if (array_vector != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(Convert.ToString(array_vector[i]) + ' ');
                }
                Console.WriteLine();
            }
        }

    }
}
