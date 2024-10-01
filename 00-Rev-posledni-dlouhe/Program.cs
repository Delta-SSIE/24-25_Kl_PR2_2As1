
namespace _00_Rev_posledni_dlouhe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] slova = { "Karel", "Eva", "Jaromír", "Iva", "Martin" };
            Console.WriteLine(PosledniDlouhe(slova, 5)); //vypíše "Martin"
            Console.WriteLine(PosledniDlouhe(slova, 7)); //vypíše "Jaromír"
            Console.WriteLine(PosledniDlouhe(slova, 12)); //vypíše prázdno
            Console.WriteLine(PosledniDlouhe(new string[0], 5));
        }

        private static string PosledniDlouhe(string[] slova, int limit)
        {
            // Najít poslední řetězec, který splňuje podmínku délky
            return slova.LastOrDefault(s => s.Length >= limit) ?? "";
        }
    }
}
