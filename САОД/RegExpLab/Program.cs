using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;


namespace RegExpLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = " фыидо, fjbld33- 2олт?";
            Console.WriteLine(str);

            Regex re = new Regex(@"."); 
            MatchCollection mc = re.Matches(str);
            foreach (var m in mc)
                Console.WriteLine(m);
        }
    }
}
