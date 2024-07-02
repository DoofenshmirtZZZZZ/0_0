using System;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{           
			Drob drob_1 = new Drob(3, 14);
			Drob drob_2 = new Drob(10, 15);
			drob_1.Print();
			drob_2.Print();
			Drob oper_1 = drob_1 + drob_2;
			Console.WriteLine("сложение");			
			oper_1.Print();
			Drob oper_2 = drob_1 - drob_2;
			Console.WriteLine("вычитание");
			oper_2.Print();
			Drob oper_3 = drob_1 * drob_2;
			Console.WriteLine("умножение");
			oper_3.Print();
			Drob oper_4 = drob_1 / drob_2;
			Console.WriteLine("деление");
			oper_4.Print();            
		}
	}
}
