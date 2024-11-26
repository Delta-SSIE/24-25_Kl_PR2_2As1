using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_060_Iface_Utvary
{
    internal class Trojuhelnik : IUtvar
    {
        public string Nazev => "trojúhelník";
        public double Strana1 { get; init; }
        public double Strana2 { get; init; }
        public double Strana3 { get; init; }

        public Trojuhelnik(double strana1, double strana2, double strana3)
        {
            Strana1 = strana1;
            Strana2 = strana2;
            Strana3 = strana3;
        }

        public double GetObsah()
        {
            double s = GetObvod() / 2;
            return Math.Sqrt(s * (s - Strana1) * (s - Strana2) * (s - Strana3));
        }

        public double GetObvod() => Strana1 + Strana2 + Strana3;
    }
}
