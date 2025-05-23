﻿namespace _02_OOP2_030_Iface_Icomparable_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Strom[] sad = new Strom[]
            {
                new Strom() {Druh = "Jabloň", Vyska = 5.5},
                new Strom() {Druh = "Smrk", Vyska = 12},
                new Strom() {Druh = "Hrušeň", Vyska = 8.2},
                new Strom() {Druh = "Třešeň", Vyska = 3.3},
                new Strom() {Druh = "Švestka", Vyska = 4.1}
            };

            foreach (Strom strom in sad)
            {
                Console.WriteLine($"{strom.Druh}: {strom.Vyska}");
            }

            Console.WriteLine();

            Array.Sort(sad);

            foreach (Strom strom in sad)
            {
                Console.WriteLine($"{strom.Druh}: {strom.Vyska}");
            }

            Strom bobrovice = new Strom() { Druh = "Borovice", Vyska = 15 };
        }
    }

    class Strom : IComparable
    {
        public string Druh { get; set; }
        public double Vyska { get; set; }


        //public int CompareTo(object? obj)
        //{
        //    return Vyska.CompareTo(((Strom)obj).Vyska); //použiju nativní porovnání podle double
        //}

        int IComparable.CompareTo(object? obj)
        {
            if (obj != null && obj is Strom druhyStrom)
            {
                if (druhyStrom.Vyska > this.Vyska)
                    return -1;
                else if (druhyStrom.Vyska < this.Vyska)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Cannot compare - invalid type");
            }
        }

        //public int CompareTo(object? obj)
        //{
        //    if (obj != null && obj is Strom druhyStrom)
        //    {
        //        double rozdil = this.Vyska - druhyStrom.Vyska;
        //        return Math.Sign(rozdil);
        //    }
        //    else
        //    {
        //        throw new Exception("Cannot compare - invalid type");
        //    }
        //}
    }
    
}
