using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace сем5
{
	public partial class Form1 : Form
	{

		List<Animals> Zoo = new List<Animals>();
		List<Button> Btm = new List<Button>();

		int lastIndex;
		Animals item;
		bool start = false;
		
		public Form1()
		{
			InitializeComponent();
		}

		public void V_button()
        {
			if (start)
			{
				foreach (var b in Btm)
				{
					b.Dispose();
				}
			}
			lastIndex = listBox1.SelectedIndex;
			item = Zoo[lastIndex];

			start = true;
			int top = 30;
			int left = 250;
			if (item is IFly)
			{
				Button button = new Button();
				button.Left = left;
				button.Top = top;
				button.Name = "IFly";
				button.Text = "Летать";
				button.FlatStyle = FlatStyle.Flat;
				button.Click += new System.EventHandler(Fly_Click);
				Btm.Add(button);

				this.Controls.Add(button);
				top += button.Height + 20;
			}
			if (item is IDig)
			{
				Button button = new Button();
				button.Left = left;
				button.Top = top;
				button.Name = "IDig";
				button.Text = "Ползать";
				button.FlatStyle = FlatStyle.Flat;
				button.Click += new System.EventHandler(Dig_Click);
				Btm.Add(button);

				this.Controls.Add(button);
				top += button.Height + 20;
			}
			if (item is ISwim)
			{
				Button button = new Button();
				button.Left = left;
				button.Top = top;
				button.Name = "ISwim";
				button.Text = "Плавать";
				button.FlatStyle = FlatStyle.Flat;
				button.Click += new System.EventHandler(Swim_Click);
				Btm.Add(button);

				this.Controls.Add(button);
				top += button.Height + 20;
			}
			if (item is IWalk)
			{
				Button button = new Button();
				button.Left = left;
				button.Top = top;
				button.Name = "IWalk";
				button.Text = "Гулять";
				button.FlatStyle = FlatStyle.Flat;
				button.Click += new System.EventHandler(Walk_Click);
				Btm.Add(button);

				this.Controls.Add(button);
				top += button.Height + 20;
			}
		}

		private void Walk_Click(object sender, EventArgs eventArgs)
		{
			textBox1.Text += "\n";
			textBox1.Text += (item as IWalk).Walk();
		}
		private void Dig_Click(object sender, EventArgs eventArgs)
		{
			textBox1.Text += "\n";
			textBox1.Text += (item as IDig).Dig();
		}
		private void Swim_Click(object sender, EventArgs eventArgs)
		{
			textBox1.Text += "\n";
			textBox1.Text += (item as ISwim).Swim();
		}
		private void Fly_Click(object sender, EventArgs eventArgs)
		{
			textBox1.Text += "\n";
			textBox1.Text += (item as IFly).Fly();
		}

		private void button1_Click(object sender, EventArgs e) 
		{
			Duck s = new Duck("Утка - ");
			listBox1.Items.Add(s.Name);
			Zoo.Add(s);
		} // Утка кнопка
		private void button2_Click(object sender, EventArgs e) 
		{
			Crocodile c = new Crocodile("Крокодил - ");
			listBox1.Items.Add(c.name);
			Zoo.Add(c);
		} // Крокодил кнопка
		private void button3_Click(object sender, EventArgs e) 
		{
			Giraffe s = new Giraffe("Жираф - ");          
			listBox1.Items.Add(s.Name);
			Zoo.Add(s);
		} // Жираф кнопка
		private void button4_Click(object sender, EventArgs e) 
		{
			Snake s = new Snake("Змея - ");
			listBox1.Items.Add(s.Name);
			Zoo.Add(s);
		} // Змея кнопка
		private void button5_Click(object sender, EventArgs e) 
		{
			Mouse s = new Mouse("Летучая мышь - ");
			listBox1.Items.Add(s.Name);
			Zoo.Add(s);
		} // Мышь кнопка

		private void button6_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			V_button();
		}
    }
}
