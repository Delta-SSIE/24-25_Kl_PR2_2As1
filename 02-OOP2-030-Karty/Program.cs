namespace _02_OOP2_030_Karty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Karta karta1 = new Karta(TypBarvy.Srdce, TypVysky.Osma);
            Karta karta2 = new Karta(TypBarvy.Zaludy, TypVysky.Desitka);

            if (karta1 > karta2)
            {
                Console.WriteLine( "První je větší než druhá");
            }
            else if (karta1 < karta2)
            {
                Console.WriteLine("Druhá je větší než první");
            }
            else if (karta1 == karta2)
            {
                Console.WriteLine("Karty mají stejnou výšku");
            }
            else
            {
                Console.WriteLine("Něco je špatně");
            }

            

        }
    }
}
