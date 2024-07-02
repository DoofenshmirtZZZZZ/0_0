using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_List
{
	public partial class Form1 : Form
	{

		MyList<string> list0 = new MyList<string>();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		private void show_all_Click(object sender, EventArgs e) // SHOW
		{
			foreach (var item in list0)
			{
				listBox.Items.Add(item);
			}
		}

		private void add_end_Click(object sender, EventArgs e) // ADD END
		{
			list0.Add(new_node.Text);
			new_node.Text = "";
		}

		private void add_begin_Click(object sender, EventArgs e) // ADD HEAD
		{
			list0.AppendFirst(new_node.Text);
			new_node.Text = "";
		}

		private void add_before_Click(object sender, EventArgs e) // ADD INDEX
		{
			int indexAdd = 0;
			indexAdd = Convert.ToInt32(index_add.Text);
			list0.AddBefore(new_node_index.Text, indexAdd);
		}

        private void get_by_index_Click(object sender, EventArgs e) // GET BY INDX
        {
			int indexGet = 0;
			int countt = 0;
			indexGet = Convert.ToInt32(index_get.Text);
			foreach (var item in list0)
			{
				
				if(indexGet == countt)
                {
					listBox.Items.Add(item);
				}
				countt++;

			}
	
		}

        private void remove_Click(object sender, EventArgs e) // REMOVE
        {
			int indexGet = 0;
			indexGet = Convert.ToInt32(index_get.Text);
			list0.Remove(indexGet);
			foreach (var item in list0)
			{
				listBox.Items.Add(item);
			}

		}

        private void clear_Click(object sender, EventArgs e) // CLEAR
        {
			list0.Clear();
			listBox.Items.Clear();
        }

        private void count_Click(object sender, EventArgs e) // COUNT
        {
			int shit = list0.Count();
			listBox.Items.Add(shit);
        }

        private void test_button_Click(object sender, EventArgs e) // TEST
        {
			list0.Add("aaa");
			list0.Add("bbb");
			list0.Add("ccc");
			list0.Add("ddd");
			foreach (var item in list0)
			{
				listBox.Items.Add(item);
			}
		}
    }
}
