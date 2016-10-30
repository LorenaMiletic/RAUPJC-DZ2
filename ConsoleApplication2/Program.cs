using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            string[] strings = integers.GroupBy(s => s)
                .Select(s => "Broj " + s.Key.ToString() + " ponavlja se " + s.Count().ToString() + " puta")
                .ToArray();
            


        }
    }
}
