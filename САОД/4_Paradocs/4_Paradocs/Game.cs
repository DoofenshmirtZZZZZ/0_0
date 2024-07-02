using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4_Paradocs
{
    class Game
    {
        Player changesСhoice;
        Player NotchangesСhoice;

        List<Street> firstPlayerList;
        List<Street> secondPlayerList;

        int countGame;
        static Random random = new Random();

        public Statistics statistics = new Statistics();


        public Game(int count)
        {
            countGame = count;
            statistics.totalGame = count;
            firstPlayerList = InitStreet(count);
            secondPlayerList = InitStreet(count);
        }

        public List<Street> InitStreet(int count)
        {
            List<Street> streets = new List<Street>();
            for (int i = 0; i < count; i++)
            {
                streets.Add(new Street());
            }
            return streets;
        }

        public void StartGames()
        {
            for (int i = 0; i < countGame; i++)
            {
                changesСhoice = new Player();
                NotchangesСhoice = new Player();
                changesСhoice.selectedElement = random.Next(0, 3);
                NotchangesСhoice.selectedElement = random.Next(0, 3);

                changesСhoice.discontItem = GetNothingInStreet(firstPlayerList[i], changesСhoice.selectedElement);
                NotchangesСhoice.discontItem = GetNothingInStreet(secondPlayerList[i], NotchangesСhoice.selectedElement);

                changesСhoice.selectedElement = AnotherСhoice(changesСhoice, firstPlayerList[i]);

                if (IsWinner(changesСhoice, firstPlayerList[i]))
                {
                    statistics.CountVinsChangesСhoice++;
                }

                if (IsWinner(NotchangesСhoice, secondPlayerList[i]))
                {
                    statistics.CountVinsNotChangesСhoice++;
                }
            }
        }

        public bool IsWinner(Player player, Street street)
        {
            int vinIndex = street.doors.FindIndex(x => x == Items.Car);
            return player.selectedElement == vinIndex;
        }

        public int AnotherСhoice(Player player, Street street)
        {
            return new int[] { 0, 1, 2 }
                .Where(x => x != player.discontItem && x != player.selectedElement)
                .First();
        }

        public int GetNothingInStreet(Street street, int discont)
        {
            Street Localstreet = street;
            List<int?> allNothingIndex = new List<int?>();
            allNothingIndex.Add(Localstreet.doors
                .FindAll(x => x == Items.nothing)
                .Select(x => Localstreet.doors.FindIndex(y => y == x))
                .FirstOrDefault());
            allNothingIndex.Add(Localstreet.doors
                .FindAll(x => x == Items.nothing)
                .Select(x => Localstreet.doors.FindLastIndex(y => y == x))
                .Where(x => x != allNothingIndex[0])
                .FirstOrDefault());
            allNothingIndex = allNothingIndex.Where(x => x != null && x != discont).ToList();
            int count = allNothingIndex.Count;
            return allNothingIndex[random.Next(0, count)].GetValueOrDefault();
        }
    }
}
