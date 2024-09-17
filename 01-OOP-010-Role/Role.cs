using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_010_Role
{
    internal class Role
    {
        private string barva;
        private int delka;

        public string Barva
        {
            get { return barva; }
            set { barva = value; }
        }

        public int Delka { 
            get => delka; 
            set => delka = value; 
        }

        private int _sirka;

        public int Sirka
        {
            get { return _sirka; }
            set { _sirka = value; }
        }

        public Role(string barva, int delka)
        {
            Barva = barva;
            Delka = delka;
        }

        public override string ToString()
        {
            return $"Role papíru, barva {Barva}, zbývá {Delka} cm";
        }


    }
}
