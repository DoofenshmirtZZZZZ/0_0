using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ohio
{
    public partial class Form_General : Form
    {
        public string[] x_1 = new string[26];
        public string[] y_1 = new string[26];
        public string[] x_2 = new string[26];
        public string[] y_2 = new string[26];
        public string[] x_ex = new string[5];
        public string[] y_ex = new string[5];
        public Form_General()
        {
            

			InitializeComponent();
			numericUpDown1.Value = 3;

			string text_property_1 = System.IO.File.ReadAllText(@"C:\Users\dasha\Documents\4 семак\ohio\property_1.txt");
			string text_property_2 = System.IO.File.ReadAllText(@"C:\Users\dasha\Documents\4 семак\ohio\property_2.txt");
			string text_exam_material = System.IO.File.ReadAllText(@"C:\Users\dasha\Documents\4 семак\ohio\exam_material.txt");

			string[] subs_property_1 = text_property_1.Split('\n');
			string[] subs_property_2 = text_property_2.Split('\n');
			string[] subs_exam_material = text_exam_material.Split('\n');
			int k = 0;



			for (int i = 0; i < 52; i++)
			{
				if (i < 26)
				{
					x_1[i] = subs_property_1[i];
					x_2[i] = subs_property_2[i];
				}
				else
				{
					y_1[k] = subs_property_1[i];
					y_2[k] = subs_property_2[i];
					k++;
				}
			}
			k = 0;
			for (int i = 0; i < 10; i++)
			{
				if (i < 5)
				{
					x_ex[i] = subs_exam_material[i];
				}
				else
				{
					y_ex[k] = subs_exam_material[i];
					k++;
				}
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			for (int i = 0; x_1.Length > i; i++)
			{
				dataGridView1.Rows.Add(x_1[i], y_1[i]);
				dataGridView2.Rows.Add(x_2[i], y_2[i]);

			}
			Obj_Mate OBJ_1 = new Obj_Mate();
			OBJ_1.set_1 = x_1;
			OBJ_1.set_2 = x_2;
			double[] Set = OBJ_1.All_Things();
			double Ek = OBJ_1.Ek(Set);
			double[,] ku = OBJ_1.Matrix_MS(Ek, Set);

			Obj_Mate OBJ_2 = new Obj_Mate();
			OBJ_1.set_1 = y_1;
			OBJ_1.set_2 = y_2;
			double[] Set_2 = OBJ_1.All_Things();
			double Ek_2 = OBJ_1.Ek(Set_2);
			double[,] ku_2 = OBJ_1.Matrix_MS(Ek_2, Set_2);

			Mate OBJ = new Mate();
			double[,] matrix = OBJ.Matrix_BIG(ku, ku_2, Set, Set_2);

			double min = OBJ.Min_Matrix(matrix, Set, Set_2);
			double max = OBJ.Max_Matrix(matrix, Set, Set_2);
			label7.Text = $"MIN: {min}";
			label8.Text = $"MAX: {max}";


			for (int k = 0; Set_2.Length > k; k++)
			{
				dataGridView3.Rows.Add(ku[k, 0], ku_2[k, 0], matrix[k, 0]);
			} // выводим все на грид
		}
    }
}
