using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTable
{
    public partial class Form1 : Form
    {
        MyHashTable hashTable;
        bool badhashed = false;
        public Form1()
        {
            InitializeComponent();
            hashTable = new MyHashTable(1000, KeysType.Phone, Hash);
            hashTable.Load();
        }
        private int Hash(string key)
        {
            long k;
            string key1 = Regex.Replace(key, @"[^\d]", "");
            if (key1 == "") k = Math.Abs(key.GetHashCode());
            else
                k = Convert.ToInt64(key1);

            int t = badhashed ? 200 : 1;

            return (int)((k * t) % 1000); 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int steps = -1;
            List<Abonent> abs = hashTable.Find(textBox1.Text, out steps);

            Abonent ab = null;

            foreach (Abonent item in abs)
            {
                steps++;
                switch (hashTable.keysType)
                {
                    case KeysType.Name:
                        if (item.Name == textBox1.Text) ab = item;
                        break;
                    case KeysType.DateOfBirthday:
                        if (item.DateOfBirthday == textBox1.Text) ab = item;
                        break;
                    case KeysType.Phone:
                        if (item.Phone == textBox1.Text) ab = item;
                        break;
                }
                if (ab != null) break;
            }
            if (ab != null)
            {
                label2.Text = $"Name: {ab.Name}";
                label3.Text = $"Phone: {ab.Phone}";
                label4.Text = $"Birthday: {ab.DateOfBirthday}";
            }
            else
            {
                label2.Text = $"Name: (null)";
                label3.Text = $"Phone: (null)";
                label4.Text = $"Birthday: (null)";
            }
            label5.Text = $"{steps} steps to find";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            hashTable.Draw(e.Graphics, 500, 400);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hashTable.keysType = KeysType.Name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hashTable.keysType = KeysType.Phone;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hashTable.keysType = KeysType.DateOfBirthday;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hashTable.Load();
            pictureBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            badhashed = checkBox1.Checked;
        }
    }
}
