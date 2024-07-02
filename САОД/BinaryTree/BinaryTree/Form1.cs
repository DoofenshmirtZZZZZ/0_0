using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        int leafs = 0;
        MyTree<int> tree = new MyTree<int>();
        BinaryTreeNode<int> root = new BinaryTreeNode<int>();
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int key = Convert.ToInt32(textBox1.Text);
            tree.Add (key);
            tree.Draw(g, panel1.Width, panel1.Height, 50);
            leafs++;
            label5.Text = (leafs).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int key = Convert.ToInt32(textBox1.Text);
            tree.Remove(key);
            tree.Draw(g, panel1.Width, panel1.Height, 50);
            leafs--;
            label5.Text = (leafs).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           label1.Text = tree.LNRm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = tree.RNLm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = tree.NLRm();
        }
    }
}
