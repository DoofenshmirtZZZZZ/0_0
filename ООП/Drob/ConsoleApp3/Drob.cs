using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
	class Drob
	{
		int num;
		int den;
		public Drob(int number_1, int number_2)
		{
			num = number_1;
			den = number_2;
		} // метод занесения значений числителя и знаменателя
		public void Print() 
		{
			Console.WriteLine(Convert.ToString(num) + '/' + Convert.ToString(den));
		} // метод визуализации хранимого рационального числа в виде десятичной дроби.
		public static Drob operator +(Drob drob_1, Drob drob_2) // оператор +
		{
			return new Drob(drob_1.num * drob_2.den + drob_2.num * drob_1.den, drob_1.den * drob_2.den);
		}
		public static Drob operator -(Drob drob_1, Drob drob_2) // оператор -
		{
			return new Drob(drob_1.num * drob_2.den - drob_2.num * drob_1.den, drob_1.den * drob_2.den);
			
		}
		public static Drob operator *(Drob drob_1, Drob drob_2) // оператор *
		{
			Drob DrobOtvet = new Drob(drob_1.num * drob_2.num, drob_2.den * drob_1.den);
			DrobOtvet.Reducing();
			return DrobOtvet;
		}
		public static Drob operator /(Drob drob_1, Drob drob_2) // оператор /
		{
			Drob DrobOtvet = new Drob(drob_1.num * drob_2.den, drob_1.den * drob_2.num);
			DrobOtvet.Reducing();
			return DrobOtvet;
		}
		void Reducing()
		{
			int number_1 = num;
			int number_2 = den;
			if (num == den) 
			{
				num = 1;
				den = 1;
				return;
			} // если знаменатель и числитель равны то дробь = 1
			while (true)
			{
				if (Math.Max(number_1,number_2)- Math.Min(number_1,number_2)!=0) // проверка на возможность сокращения
				{
					if (number_1>number_2)
					{
						number_1 = number_1 - number_2;
					}
					else
					{
						number_2 = number_2 - number_1;
					}
				}
				else
				{
					num = num / number_1;
					den = den / number_2;
					return;
				}
			}
		} // метод для сокращения дроби
		
		
	}
}
