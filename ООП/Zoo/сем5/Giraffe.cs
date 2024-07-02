using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем5
{
    class Giraffe : Animals, IWalk, IDig
    {
        string name;

        public string Name { get { return name; } private set { name = value; } }

        public Giraffe(string N)
        {
            name = N;
        }
        public string Dig()
        {
            return "   Я " + name + " копаю";
        }

       

        public string Walk()
        {
            return "   Я " + name + " хожу";
        }
        public static List<string> Methods()
        {
            List<string> vs = new List<string> { "Dig",  "Walk" };
            return vs;
        }
    }
}
