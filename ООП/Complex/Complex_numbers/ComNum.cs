using System;
using System.Collections.Generic;
using System.Text;

namespace Complex_numbers
{
	class ComNum
	{
		double Re;
		double Im;
		public ComNum(double a1, double b1)
		{
			Re = a1;
			Im = b1;
		}
		public void Print()
		{
			if (Im < 0)
			{
				Console.WriteLine(Convert.ToString(Re) + " - " + Convert.ToString(Math.Abs(Im)) + 'i');
			}
			else if(Im == 0)
			{
				Console.WriteLine(Convert.ToString(Re));
			}
			else if (Re == 0)
			{
				Console.WriteLine(Convert.ToString(Math.Abs(Im)) + 'i');
			}
			else
			{
				Console.WriteLine(Convert.ToString(Re) + " + " + Convert.ToString(Im) + 'i');
			}
			
			
		}
		public static ComNum operator +(ComNum first, ComNum second)
		{

			return new ComNum(first.Re + second.Re, first.Im + second.Im);
		}
		public static ComNum operator -(ComNum first, ComNum second)
		{
			return new ComNum(first.Re - second.Re, first.Im - second.Im);
		}
		public static ComNum operator *(ComNum first, ComNum second)
		{
			Console.WriteLine($"({first.Re} + {first.Im}i)*({second.Re} + {second.Im}i)");
			return new ComNum(first.Re * second.Re - first.Im * second.Im, first.Re * second.Im + second.Re * first.Im);
		}
		public static ComNum operator /(ComNum first, ComNum second)
		{
			return new ComNum((first.Re * second.Re + first.Im * second.Im) / (second.Re * second.Re + second.Im * second.Im), (first.Im * second.Re - first.Re * second.Im) / (second.Re * second.Re + second.Im * second.Im));
		}

		public double Trigonometr()
		{
			double r = 0;
			double f = 0;
			double Trigonometr = 0;
			r = Math.Sqrt(Re * Re + Im * Im);

			if ((Re > 0) && (Im > 0))
				f = Math.Atan(Im / Re);
			if ((Re > 0) && (Im < 0))
				f = Math.Atan(Im / Re) * (-1);
			if ((Re < 0) && (Im > 0))
				f = Math.PI - Math.Atan(Im / Re);
			if ((Re < 0) && (Im > 0))
				f = (-1) * Math.PI + Math.Atan(Im / Re);
			if ((Re == 0) && (Im > 0))
				f = Math.PI / 2;
			if ((Re == 0) && (Im < 0))
				f = (-1) * Math.PI / 2;
			if ((Re > 0) && (Im == 0))
				f = 0;
			if ((Re < 0) && (Im == 0))
				f = Math.PI;

			Trigonometr = r * ((Math.Cos(f)) + (Math.Sin(f)));
			
			return Trigonometr;

		}
	}
}
