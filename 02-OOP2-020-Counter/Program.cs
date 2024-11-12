namespace _02_OOP2_020_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Counter cnt = new Counter();
            Counter cnt = new StepCounter(4);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Počet je {cnt.Count}");
                cnt.Next();
            }

            cnt.Reset();
            Console.WriteLine($"Počet je {cnt.Count}");
            cnt.Next();

            Console.WriteLine();

            DownCounter dcnt = new DownCounter(5, 25);
            while (!dcnt.IsFinished)
            {
                Console.WriteLine($"Počet je {dcnt.Count}");
                dcnt.Next();
            }
        }
    }
}
