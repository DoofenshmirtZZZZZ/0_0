using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем5
{
    public class Crocodile : Animals, IWalk , ISwim
    {
        public string name;
        public string Walk()
        {
            return "   Я " + name + " ползаю";
        }
        public string Swim()
        {
            return "   Я " + name + " плаваю";
        }


        public static List<string> Methods()
        {
            List<string> vs = new List<string> { "Swim", "Walk" };
            return vs;
        }

        public Crocodile(string name)
        {
            this.name = name;
        }
    }
}
