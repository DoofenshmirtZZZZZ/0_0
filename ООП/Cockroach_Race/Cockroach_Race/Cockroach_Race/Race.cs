using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cockroach_Race
{
    class Race
    {
        int N;
        public Race(int CockroachCount)
        {
            N = CockroachCount;
        }
        Cockroach[] Cockroach;
        public void SetNCockroach(int N)
        {
            TextBox[] textbox = new TextBox[N];
        }
    }
}
