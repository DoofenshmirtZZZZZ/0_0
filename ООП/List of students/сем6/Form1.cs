using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using SolrNet.Utils;


namespace сем6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }
        
        

        List<Student> students = new List<Student>();
        bool f = false;
        bool f1 = false;
        int index = -1;



        private void AddButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            pictureBox1.ImageLocation = "";

            f = true;
           
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (f && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                Student st = new Student { FirstSurname = textBox1.Text, FirstName = textBox2.Text, FirstPatronymic = textBox3.Text, Group = textBox4.Text, FotoName = textBox5.Text };
                students.Add(st);
                //File.WriteAllText("students.json", JsonConvert.SerializeObject(st));

                pictureBox1.ImageLocation = textBox5.Text;

                string jsStr = JsonSerializer.Serialize<List<Student>>(students);
                File.WriteAllText(@".\students.txt", jsStr);

                listBox1.Items.Add(st.FirstName + st.FirstSurname + st.FirstPatronymic);

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                f = false;
            }
            if (f1)
            {
                students[index].FirstSurname = textBox1.Text;
                students[index].FirstName = textBox2.Text;
                students[index].FirstPatronymic = textBox3.Text;
                students[index].Group = textBox4.Text;
                students[index].FotoName = textBox5.Text;

                pictureBox1.ImageLocation = students[index].FotoName;

                listBox1.Items[index] = students[index].FirstName + students[index].FirstSurname + students[index].FirstPatronymic;

                string jsStr = JsonSerializer.Serialize<List<Student>>(students);
                File.WriteAllText(@".\students.txt", jsStr);

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                f1 = false;
            }
           
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\students.txt"))
            {
                string jsStr = File.ReadAllText(@".\students.txt");
                students = JsonSerializer.Deserialize<List<Student>>(jsStr);

                foreach (var pers in students)
                {
                    listBox1.Items.Add(pers.FirstName + pers.FirstSurname+ pers.FirstPatronymic);
                }
                OpenButton.Enabled = false;
            }        
        }


        private void ChangeButton_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;           

            f1 = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;

                textBox1.Text = students[index].FirstSurname;
                textBox2.Text = students[index].FirstName;
                textBox3.Text = students[index].FirstPatronymic;
                textBox4.Text = students[index].Group;
                textBox5.Text = students[index].FotoName;

            pictureBox1.ImageLocation = students[index].FotoName;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void DeletButto_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                listBox1.Items.RemoveAt(index);
                students.RemoveAt(index);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                pictureBox1.ImageLocation = textBox5.Text;

                string jsStr = JsonSerializer.Serialize<List<Student>>(students);
                File.WriteAllText(@".\students.txt", jsStr);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
