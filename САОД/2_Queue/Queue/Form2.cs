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
    public partial class Form2 : Form
    {
        Queue<string> queue0 = new Queue<string>();
        Queue<string> queue1 = new Queue<string>();
        Queue<string> queue2 = new Queue<string>();
        Queue<string> queue3 = new Queue<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(textBox4.Text);
            for (int i = 1; i <= k; i++)
            {
                listBox1.Items.Add(i);
                queue0.Push(Convert.ToString(i));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (queue0.tek == -1)
            {
                MessageBox.Show("Никого нет");
            }
            else
            {
                Random rnd = new Random();
                int slot = rnd.Next(1, 4);
                if (slot == 1)
                {
                    textBox1.Clear();
                    queue1.Clear();
                    queue1.Push(Convert.ToString(listBox1.Items[0]));
                    listBox1.Items.RemoveAt(0);
                    textBox1.Text = queue1.nums[0];
                }
                else if (slot == 2)
                {
                    textBox2.Clear();
                    queue2.Clear();
                    queue2.Push(Convert.ToString(listBox1.Items[0]));
                    listBox1.Items.RemoveAt(0);
                    textBox2.Text = queue2.nums[0];
                }
                else if (slot == 3)
                {
                    textBox3.Clear();
                    queue3.Clear();
                    queue3.Push(Convert.ToString(listBox1.Items[0]));
                    listBox1.Items.RemoveAt(0);
                    textBox3.Text = queue3.nums[0];
                }
                queue0.Pop();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
