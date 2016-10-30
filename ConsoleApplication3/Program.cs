using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender _Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public enum Gender
        {
            Male, Female
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Student;
            if (temp == null)
                return false;

            if (this.Jmbag == temp.Jmbag)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashJmbag = Jmbag == null ? 0 : Jmbag.GetHashCode();

            int hash = hashName ^ hashJmbag;
            return hash;
        }


        void Example1()
        {
            var list = new List<Student>()
        {
            new Student (" Ivan ", jmbag :" 001234567 ")
        };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
        }

        void Example2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudents = list.Distinct().Count();
        }
    }
}
