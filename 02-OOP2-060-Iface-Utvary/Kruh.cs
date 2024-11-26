using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_060_Iface_Utvary
{
    internal class Kruh
    {
        public string Nazev => "kruh";
        public double Polomer { get; init; }

        public Kruh(double strana)
        {
            Polomer = strana;
        }

        public double GetObsah() => Math.PI * Polomer * Polomer;
        public double GetObvod() => 2 * Math.PI * Polomer;
    }
}
