using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_060_Iface_Utvary
{
    internal class Ctverec : IUtvar
    {
        public string Nazev => "čtverec";
        public double Strana { get; init; }

        public Ctverec(double strana)
        {
            Strana = strana;
        }

        public double GetObsah() => Strana * Strana;
        public double GetObvod() => 4 * Strana;
        public override string ToString() => $"Čtverec o straně {Strana}";

        public string BlaBla() => "Blablabla";
    }
}
