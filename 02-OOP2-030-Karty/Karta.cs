using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_030_Karty
{
    enum TypBarvy { Srdce, Kule, Zelene, Zaludy }
    enum TypVysky { Sedma, Osma, Devitka, Desitka, Spodek, Svrsek, Kral, Eso }

    internal class Karta : IComparable
    {
        public TypBarvy Barva { get; init; }
        public TypVysky Vyska { get; init; }

        public Karta(TypBarvy barva, TypVysky vyska)
        {
            Barva = barva;
            Vyska = vyska;
        }

        public int CompareTo(object? obj)
        {
            return Vyska.CompareTo(((Karta)obj).Vyska);
        }

        public static bool operator <(Karta karta1, Karta karta2)
        {
            //return karta1.CompareTo(karta2) < 0;
            return karta1.Vyska < karta2.Vyska;
        }
        public static bool operator >(Karta karta1, Karta karta2)
        {
            return karta1.Vyska > karta2.Vyska;
        }

        public static bool operator <=(Karta karta1, Karta karta2)
        {
            //return karta1.CompareTo(karta2) < 0;
            return karta1.Vyska <= karta2.Vyska;
        }
        public static bool operator >=(Karta karta1, Karta karta2)
        {
            return karta1.Vyska >= karta2.Vyska;
        }

        public static bool operator ==(Karta karta1, Karta karta2)
        {
            return karta1.Vyska == karta2.Vyska;
        }
        public static bool operator !=(Karta karta1, Karta karta2)
        {
            return karta1.Vyska != karta2.Vyska;
        }
        //public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
