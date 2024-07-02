using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем5
{
    class Snake : Animals, ISwim, IDig
    {
        string name;

        public string Name { get { return name; } private set { name = value; } }

        public Snake(string N)
        {
            name = N;
        }
        public string Dig()
        {
            return "   Я " + name + " ползаю";
        }

    

        public string Swim()
        {
            return "   Я " + name + " плаваю";
        }
        public static List<string> Methods()
        {
            List<string> vs = new List<string> { "Swim", "Dig" };
            return vs;
        }

       
    }
}
