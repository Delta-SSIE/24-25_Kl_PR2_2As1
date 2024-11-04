namespace _02_OOP2_010_Savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kun konik = new Kun("Hopla");
            //konik.Cvalej();
            //konik.Dychej();

            //Velryba mobyDick = new Velryba("Moby Dick", 13);
            //mobyDick.Dychej();
            //mobyDick.Plav();
            ////mobyDick.Cvalej();

            Savec kobylka = new Kun("Linda");
            Savec plejtvak = new Velryba("Plejtvak ne tak obrovsky", 2);

            ////mobyDick.Hmotnost;

            //kobylka.Dychej(); //lze - umí každý savec
            ////kobylka.Cvalej(); //nezkompiluje - savec nemá cválej

            //Kun pravaKobyla = (Kun)kobylka; //přetypování
            //pravaKobyla.Cvalej();

            //// Kun falesnaKobyla = (Kun)plejtvak; //není chyba kompilace, ale až chyba běhu
            //// falesnaKobyla.Cvalej(); //referencováno jako kun - nabidne i cvalani

            Console.WriteLine("Procházení pole");

            //Savec[] zvirata = new Savec[] { kobylka, plejtvak, new Kun("Hatatitla") };
            //foreach (Savec zvire in zvirata)
            //    zvire.OzviSe();

            Console.WriteLine(kobylka.Jmeno);
            ((Kun)kobylka).Cvalej();
            Console.WriteLine(kobylka.Jmeno);
            //kobylka.Jmeno = "l";

        }
    }

    class Savec
    {
        public string Jmeno { get; protected set; }

        public Savec(string jmeno)
        {
            Jmeno = jmeno;
        }

        public void Dychej()
        {
            Console.WriteLine("Nádech - výdech");
        }
        public void SajMleko()
        {
            Console.WriteLine("Cuc cuc cuc");
        }

        public virtual void OzviSe()
        {
            Console.WriteLine("Dělám zvuk");
        }
    }

    class Kun : Savec
    {
        public Kun(string jmeno) : base(jmeno)
        {

        }
        public void Cvalej()
        {
            Console.WriteLine("Hop - hop - hop");
            Jmeno += "Hop";
        }

        public override void OzviSe()
        {
            Console.WriteLine("Íhahá");
        }
    }

    class Velryba : Savec
    {
        public int Hmotnost { get; private set; }

        public Velryba(string jmeno, int hmotnost) : base(jmeno)
        {
            Hmotnost = hmotnost;
        }

        public void Plav()
        {
            Console.WriteLine("Čvacht - čvacht");
        }

        public override void OzviSe()
        {
            Console.WriteLine("Huí");
        }
    }

}
