using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _02_OOP2_040_Zamestnanci
{
    //Dědí ze třídy Zamestnanec
    internal class StalyZamestnanec : Zamestnanec
    {
        private int _mzda;

        //V konstruktoru přímo přijímá měsíční mzdu(celé číslo) a ukládá si ji tak, aby ji metoda Mzda() vracela
        public StalyZamestnanec(string jmeno, string prijmeni, int mzda) : base(jmeno, prijmeni)
        {
            _mzda = mzda;
        }

        public override int Mzda()
        {
            return _mzda;
        }
    }
}
