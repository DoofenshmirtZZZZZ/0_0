using System;

namespace Matrix
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Console.WriteLine("*** Операции над матрицами ***");

			Console.WriteLine(" ");

			Console.WriteLine("Кол-во строк матрицы: 3");
			int Width = 3;
			Console.WriteLine("Кол-во столбцов матрицы: 3");
			int Height = 3;

			Console.WriteLine(" ");

			Console.WriteLine("Первая Матрица: \n");
			Matrix array_matrix1 = new Matrix(Width, Height);
			array_matrix1.Print();
						
			Console.WriteLine("Вторая Матрица: \n");
			Matrix array_matrix2 = new Matrix(Width, Height);
			array_matrix2.Print();
						
			Matrix shiiiiiiiiit = array_matrix1 * array_matrix2;
			Console.WriteLine(" ");
			shiiiiiiiiit.Print_ym();
						
			Console.WriteLine("Вектор: ");
			Console.WriteLine(" ");
			var vector1 = new Vector(3);
			vector1.Print();
						
			Vector shiiiiiiiiit_2 = array_matrix1 * vector1;
			Console.WriteLine(" ");
			shiiiiiiiiit_2.Print_ym();
		}
	}
}
