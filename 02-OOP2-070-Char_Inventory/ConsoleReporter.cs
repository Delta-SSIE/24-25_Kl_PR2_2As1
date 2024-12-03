using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class ConsoleReporter : IReporter
    {
        public void Report(string message)
        {
            Console.WriteLine(message);
        }

        public void Separate()
        {
            Console.WriteLine(new string('-', 20));
        }
    }
}
