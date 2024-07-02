using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queue
{
    public partial class Form1 : Form
    {
        Queue<string> queue1 = new Queue<string>();
        public Form1()
        {
            
            InitializeComponent();
            Form2 newForm = new Form2();
            
            newForm.Show();
        }

       
    }
}
