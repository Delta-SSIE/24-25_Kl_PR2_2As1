using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_015_Obdelnik
{
    internal class Obdelnik
    {
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }

        public Obdelnik(double stranaA, double stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }

        public double Obsah()
        {
            return StranaA * StranaB;
        }

        public double Obvod()
        {
            return 2 * (StranaA + StranaB);
        }

        public override string ToString()
        {
            return $"Obdélník o stranách {StranaA} a {StranaB}";
        }
    }
}
