using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем5
{
    public class Duck : Animals, ISwim, IFly, IWalk
    {
        string name;

        public string Name { get { return name;} private set { name = value; } }

        public Duck(string N)
        {
            name = N;
        }

        public string Fly()
        {
            return "Я " + name + " летаю";
        }

        public string Swim()
        {
            return "   Я " + name + " плаваю";
        }
        public static List<string> Methods()
        {
            List<string> vs = new List<string> { "Swim", "Walk", "Fly" };
            return vs;
        }

        public string Walk()
        {
            return "   Я " + name + " прогуливаюсь";
        }

      
    }
}
