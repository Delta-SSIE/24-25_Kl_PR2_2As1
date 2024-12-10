using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_040_Zamestnanci
{
    internal class Firma
    {
        private List<Zamestnanec> _personal = new List<Zamestnanec>();

        // Má veřejné metody Zamestnej(zamestnanec) a Propust(zamestnanec), kterým předáme instanci nějakého zaměstnance a firma si jej připíše na svůj seznam. (Nápověda: použijte List - nebo by se hodil HashSet, ale ten si musíte dohledat)
        public void Zamestnej(Zamestnanec z)
        {
            if (!_personal.Contains(z))
                _personal.Add(z);
        }

        public void Propust(Zamestnanec z)
        {
            _personal.Remove(z);
        }

        //Má veřejnou metodu Vyplata, která vypíše pod sebe na řádky všechny zaměstnance spolu s částkou, která jim bude vyplacena a pod to napíše celkovou sumu výplat.
        public void Vyplata()
        {
            int total = 0;
            int mzda;

            foreach (Zamestnanec z in _personal)
            {
                mzda = z.Mzda();
                total += mzda;
                Console.WriteLine($"{z.Prijmeni} {z.Jmeno} : {mzda} Kč");
            }

            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Celkem {total} Kč");
        }
    }
}
