namespace _02_OOP2_060_Iface_Utvary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtvar[] utvary = new IUtvar[4];
            utvary[0] = new Ctverec(3);
            utvary[1] = new Kruh(3);
            utvary[2] = new Trojuhelnik(3,4,5);
            utvary[3] = new Ctverec(1);


            double obvodTotal = utvary.Sum(x => x.GetObvod());
            double obsahTotal = utvary.Sum(x => x.GetObsah());

            //double obvodTotal = 0;
            //double obsahTotal = 0;
            foreach (IUtvar utvar in utvary)
            {
                Console.WriteLine(utvar);
                //obvodTotal += utvar.GetObvod();
                //obsahTotal += utvar.GetObsah();
            }
            Console.WriteLine($"Celkový obvod je {obvodTotal:0.00} a obsah je {obsahTotal:0.00}.");

            Console.WriteLine();

            Dictionary<string, int> pocty = [];

            foreach (IUtvar utvar in utvary)
            {
                if (pocty.ContainsKey(utvar.Nazev))
                    pocty[utvar.Nazev]++;
                else
                    pocty[utvar.Nazev] = 1;
            }

            foreach (var kvp in pocty)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine();

            
            PlechovkaBarvy plechovka = new PlechovkaBarvy(4, 0.1);
            
            Console.WriteLine(plechovka);
            
            foreach (IUtvar utvar in utvary)
            {
                bool uspech = plechovka.Obarvi(utvar);
                Console.WriteLine($"{utvar} : {(uspech ? "úspěch" : "nevyšlo")}");
                Console.WriteLine(plechovka);
            }
        }
    }
}
