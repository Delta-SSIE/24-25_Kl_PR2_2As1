using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_040_Zamestnanci
{
    //Abstraktní třída
    internal abstract class Zamestnanec
    {
        //  s vlastnostmi Jmeno, Prijmeni(řetězce), které lze veřejně číst, ale nastavit je může jen konstruktor
        public string Jmeno { get; private init; }
        public string Prijmeni { get; private init; }

        //  s konstruktorem, kterému se Jmeno a Prijmeni předávají
        protected Zamestnanec(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        //  s abstraktní metodou Mzda() (celé číslo)
        public abstract int Mzda();
    }
}
