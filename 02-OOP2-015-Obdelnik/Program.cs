namespace _02_OOP2_015_Obdelnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik abcd = new Obdelnik(5, 7);
            Console.WriteLine(abcd);
            Console.WriteLine(abcd.Obsah());

            Ctverec efgh = new Ctverec(4);
            Console.WriteLine(efgh);
        }
    }
}
