using System;

namespace _5_Plenty
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создаем множества.
			var set1 = new MySet<int>()
			{
				1, 2, 3, 4, 5, 6
			};

			var set2 = new MySet<int>()
			{
				4, 5, 6, 7, 8, 9
			};

			var set3 = new MySet<int>()
			{
				2, 3, 4
			};

			// Выполняем операции со множествами.
			var union = MySet<int>.Union(set1, set2);
			var difference = MySet<int>.Difference(set1, set2);
			var intersection = MySet<int>.Intersection(set1, set2);
			var subset1 = MySet<int>.Subset(set3, set1);
			var subset2 = MySet<int>.Subset(set3, set2);

			// Выводим исходные множества на консоль.
			PrintSet(set1, "1 множество: ");
			PrintSet(set2, "2 множество: ");
			PrintSet(set3, "3 множество: ");

			// Выводим результирующие множества на консоль.
			PrintSet(union, "Объединение 1 и 2 множества: ");
			PrintSet(difference, "Разность 1 и 2 множества: ");
			PrintSet(intersection, "Пересечение 1 и 2 множества: ");

			// Выводим результаты проверки на подмножества.
			if (subset1)
			{
				Console.WriteLine("3 множество является подмножеством 1.");
			}
			else
			{
				Console.WriteLine("3 множество не является подмножеством 1.");
			}

			if (subset2)
			{
				Console.WriteLine("3 множество является подмножеством 2.");
			}
			else
			{
				Console.WriteLine("3 множество не является подмножеством 2.");
			}

			Console.ReadLine();
		}

   
		private static void PrintSet(MySet<int> set, string title)
		{
			Console.Write(title);
			foreach (var item in set)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}
	}
}
