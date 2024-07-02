using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4_Paradocs
{
    public enum Items
    {
        Car = 1,
        nothing = 2
    }
    class Program
    {
        public class Shool
        {
            static void Main(string[] args)
            {
                Console.Write($"Введите количество игр: ");
                Game game = new Game(Convert.ToInt32(Console.ReadLine()));
                game.StartGames();

                double percentСhangesСhoice =
                    (Convert.ToDouble(game.statistics.CountVinsChangesСhoice)
                    / game.statistics.totalGame) * 100;
                Console.WriteLine($"Процент победы где игрок меняет свое решение {percentСhangesСhoice}");
                double percentNotСhangesСhoice =
                    (Convert.ToDouble(game.statistics.CountVinsNotChangesСhoice)
                    / game.statistics.totalGame) * 100;
                Console.WriteLine($"Процент победы где игрок остается при своем изначальном выборе {percentNotСhangesСhoice }");
                Console.ReadKey();
            }
        }


        
    }
}
