using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем6
{
    class Student
    {
        string name;
        string surname;
        string patronymic;
        string fotoName;
        string group;
        public string FirstName { get { return name; } set { name = value; } }
        public string FirstSurname { get { return surname; }  set { surname = value; } }
        public string FirstPatronymic { get { return patronymic; }  set { patronymic = value; } }
        public string FotoName { get { return fotoName; }  set { fotoName = value; } }
        public string Group { get { return group; }  set { group = value; } }
    }
}
