using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace HashTable
{
    public delegate int HashFunctionMethod(string key);
    class MyHashTable
    {
        List<Abonent>[] table;

        public int rowCount
        {
            get; set;
        }

        public KeysType keysType
        {
            get; set;
        }

        HashFunctionMethod hashFunc;
        public MyHashTable(int rowCount, KeysType keys, HashFunctionMethod hfc)
        {
            this.rowCount = rowCount;
            keysType = keys;
            hashFunc = hfc;
            table = new List<Abonent>[rowCount];
        }
        public List<Abonent> Find(string key, out int stepCount)
        {
            stepCount = hashFunc(key);
            return table[hashFunc(key)];
        }
        public void Load()
        {
            table = new List<Abonent>[rowCount];
            StreamReader sr = new StreamReader("People.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] abonent = sr.ReadLine().Split(';');
                Abonent ab = new Abonent();
                ab.Name = abonent[1];
                ab.Phone = abonent[2];
                ab.DateOfBirthday = abonent[3];
                int q = -1;
                switch (keysType)
                {
                    case KeysType.Name:
                        q = hashFunc(ab.Name);
                        break;
                    case KeysType.DateOfBirthday:
                        q = hashFunc(ab.DateOfBirthday);
                        break;
                    case KeysType.Phone:
                        q = hashFunc(ab.Phone);
                        break;
                    default:
                        throw new Exception();
                }
                if (table[q]==null)
                {
                    table[q] = new List<Abonent>();
                }
                table[q].Add(ab);
            }
        }
        public void Draw(Graphics g, float width, float height)
        {
            int max_count = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                    if (max_count < table[i].Count) max_count = table[i].Count;
            }
            float h = height / table.Length;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                    g.FillRectangle(Brushes.Green, 0, i * h, width / max_count * table[i].Count, h);
            }
        }
    }
}
