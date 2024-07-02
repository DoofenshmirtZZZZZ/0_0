using System;

namespace Complex_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ComNum first = new ComNum(1, 5);
            first.Print();
            ComNum second = new ComNum(5, 1);
            second.Print();
            
            Console.WriteLine($"{first.Trigonometr()} ");
            Console.WriteLine($"{second.Trigonometr()} ");
            Console.WriteLine("__________________________");
            Console.WriteLine("1. Сложение");
            ComNum third = first + second;
            double sum = first.Trigonometr() + second.Trigonometr();
            Console.WriteLine($"{sum}");
            third.Print();
            Console.WriteLine("2. Вычитание");
            ComNum fourth = first - second;
            double razn = first.Trigonometr() - second.Trigonometr();
            Console.WriteLine($"{razn}");
            fourth.Print();
            Console.WriteLine("3. Умножение по формуле (Re1 + Im1)*(Re2 + Im2)");
            ComNum fifth = first * second;
            double ymn = first.Trigonometr() * second.Trigonometr();
            Console.WriteLine($"{ymn}");
            fifth.Print();
            Console.WriteLine("4. Деление домножая на сопряженное");
            ComNum sixth = first / second;
            double del = first.Trigonometr() / second.Trigonometr();
            Console.WriteLine($"{del}");
            sixth.Print();
        }
    }
}
