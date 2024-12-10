using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal interface IReporter
    {
        void Report(string message);
        void Separate();
    }
}
