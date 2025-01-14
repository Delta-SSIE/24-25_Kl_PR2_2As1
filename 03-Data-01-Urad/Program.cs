namespace _03_Data_01_Urad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double pstPrichodu = 1d / 6; //cca + clovek za 6 minut
            int minTrvani = 1;
            int maxTrvani = 24;
            int pocitadloLidi = 1;
            int konec = 600;

            Clovek[] lide = 
            {
                new Clovek("Karel", 3),
                new Clovek("Eva", 7),
                new Clovek("Iva", 1),
                new Clovek("Jeňýk", 4),
                new Clovek("Karel", 12),

            };

            Prepazka[] prepazky = new Prepazka[]
            {
                new Prepazka("A"),
                new Prepazka("B"),
                //new Prepazka("C"),
            };

            Queue<Clovek> fronta = new Queue<Clovek>();
            //naplnění fronty
            foreach (var osoba in lide)
            {
                fronta.Enqueue(osoba);
            }

            int cas = 0;
            //while (fronta.Count > 0) //dokud ve frontě někdo je
            while (cas < konec)
            {
                foreach (Prepazka p in prepazky)
                {
                    if (fronta.Count < 1) //případ volných přepážek, nejsou ale lidi
                        break;

                    if (p.KdyBudeVolno <= cas)
                    {
                        Clovek zakaznik = fronta.Dequeue();
                        p.Vyrid(zakaznik);
                        Console.WriteLine($"Přepážka {p.ID}: {zakaznik.Jmeno} ({cas} - {cas + p.KdyBudeVolno})");
                    }

                }

                //bude nový člověk?
                if (rnd.NextDouble() < pstPrichodu)
                {
                    Clovek novy = new Clovek(pocitadloLidi.ToString(), rnd.Next(minTrvani, maxTrvani + 1));
                    pocitadloLidi++;
                    fronta.Enqueue(novy);
                    Console.WriteLine($"Čas {cas}: Nový člověk {novy.Jmeno} ({novy.Trvani})");
                }
                cas++;
            }
        }
    }

    class Prepazka
    {
        public string ID { get; private set; }
        public int KdyBudeVolno { get; private set; }

        public Prepazka(string iD)
        {
            ID = iD;
            KdyBudeVolno = 0;
        }

        public void Vyrid(Clovek clovek)
        {
            KdyBudeVolno += clovek.Trvani;
        }
    }

    class Clovek
    {
        public string Jmeno { get; private set; }
        public int Trvani { get; private set; }

        public Clovek(string jmeno, int trvani)
        {
            Jmeno = jmeno;
            Trvani = trvani;
        }
    }
}
