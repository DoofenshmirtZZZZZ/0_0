using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6_Uzniki
{
	class Program
	{
		static Random rand = new Random();
		static void Main(string[] args)
		{
			int uspekhTatcic = 10000;
			int uspekhRand = 10000;
			List<bool> used = new List<bool>();
			List<int> usedint = new List<int>();
			int choosen = 0;
			bool succes = true;

			for (int k = 0; k < 10000; k++)
			{
				// заполняем
				for (int i = 0; i < 100; i++)
				{
					used.Add(false);
					usedint.Add(-1);
				}
				for (int i = 0; i < 100; i++)
				{
					choosen = rand.Next(0, 100);
					while (used[choosen])
						choosen = rand.Next(0, 100);
					used[choosen] = true;
					usedint[i] = choosen;
				}

				succes = true;
				// для рандомной стратегии
				for (int j = 0; j < 100; j++)
				{
					used.Clear();
					for (int i = 0; i < 100; i++)
						used.Add(false);
					for (int c = 0; c < 50; c++)
					{
						choosen = rand.Next(0, 100);
						while (used[choosen])
							choosen = rand.Next(0, 100);
						used[choosen] = true;
						if (usedint[choosen] == j)
							break;
						else if (c == 49)
							succes = false;
					}
					if (!succes)
					{
						uspekhRand -= 1;
						break;
					}
				}
				used.Clear();

				succes = true;
				// для продуманной стратегии
				for (int j = 0; j < 100; j++)
				{
					choosen = j;
					for (int c = 0; c < 50; c++)
					{
						if (usedint[choosen] == j)
						{
							break;
						}
						else if (c == 49)
						{
							succes = false;
						}
						else choosen = usedint[choosen];
					}
					if (!succes)
					{
						uspekhTatcic -= 1;
						break;
					}
				}
			}
			Console.WriteLine(uspekhRand.ToString() + " / 10 000 в которой узники выбирают ящики случайным образом");
			Console.WriteLine(uspekhTatcic.ToString() + " / 10 000 в которой узники выбирают ящики, предварительно договорившись о вышеозначенной стратегии");
			Console.WriteLine($"Итог: в случае рандома вероятность победы - 0, а в случае договора {uspekhTatcic/100}% ") ;

		}
	}
}
