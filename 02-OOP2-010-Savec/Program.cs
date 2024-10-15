namespace _02_OOP2_010_Savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kun kobyla = new Kun();
            kobyla.Dychej();
            kobyla.Cvalej();

            Velryba mobyDick = new Velryba();
            mobyDick.Plav();
            mobyDick.Cvalej();
        }
    }

    class Savec
    {
        public void Dychej()
        {
            Console.WriteLine("Nádech - výdech");
        }
        public void SajMleko()
        {
            Console.WriteLine("Cuc cuc cuc");
        }
    }

    class Kun : Savec
    {
        public void Cvalej()
        {
            Console.WriteLine("Hop hop");
        }
    }

    class Velryba : Savec
    {
        public void Plav()
        {
            Console.WriteLine("Čvachty čvacht");
        }
    }
}
