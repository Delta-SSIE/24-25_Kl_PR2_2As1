namespace _03_Data_05_Generics_Randomizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [1, 2, 3, 4, 5, 6, 7];
            GenericRandomizer<int> randomizer = new(nums);
            while (randomizer.Remaining > 0)
            {
                Console.WriteLine($"Další číslo je {randomizer.Next()}");
            }

            Console.WriteLine();

            string[] names = ["Anna", "Marie", "Kateřina", "Eliška"];
            GenericRandomizer<string> randomizer2 = new(names);
            while (randomizer2.Remaining > 0)
            {
                Console.WriteLine($"Další jméno je {randomizer2.Next()}");
            }
        }
    }
}
