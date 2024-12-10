using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _02_OOP2_060_Iface_Utvary
{
    internal class PlechovkaBarvy
    {
        //bude v konstruktoru dostávat desetinná čísla objem a vydatnost, která si uloží.Čísla znamenají, kolik mililitrů v "pixle" je a kolik je třeba mililitrů na cm².
        private double objem;
        private double vydatnost;

        public PlechovkaBarvy(double objem, double vydatnost)
        {
            this.objem = objem;
            this.vydatnost = vydatnost;
        }

        //bude mít veřejnou metodu ToString(), která bude vracet něco jako "Plechovka barvy, zbývá jí ještě na 60 cm²".
        public override string ToString()
        {
            double zbyva = objem / vydatnost;
            return $"Plechovka barvy, zbývá jí ještě na {zbyva:0.00} cm²";
        }

        //bude mít veřejnou metodu Obarvi(), která obrdží IUtvar a pokud je v plechovce dost barvy na jeho obarvení, sníží svůj objem a vrátí true (úspěch), jinak si ponechá původní objem a vrátí false (neúspěch)
        public bool Obarvi(IUtvar utvar)
        {
            double spotreba = utvar.GetObsah() * vydatnost;
            if (spotreba <= objem)
            {
                objem -= spotreba;
                return true;
            }    
            else
            {
                return false;
            }
        }
    }
}
