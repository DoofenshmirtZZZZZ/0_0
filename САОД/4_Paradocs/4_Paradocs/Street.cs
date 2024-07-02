using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Paradocs
{
    class Street
    {
        public List<Items> doors;
        static Random random = new Random();
        public Street()
        {
            int car = random.Next(0, 3);
            doors = new List<Items>() { Items.nothing, Items.nothing, Items.nothing };
            doors[car] = Items.Car;
        }
    }
}
