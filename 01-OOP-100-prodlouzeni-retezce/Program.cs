using System.Diagnostics;
using System.Text;

namespace _01_OOP_100_prodlouzeni_retezce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder builder = new StringBuilder();

            int count = 200000;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            //for (int i = 0; i < count; i++)
            //{
            //    str += 'A';
            //}
            
            for (int i = 0; i < count; i++)
            {
                builder.Append('A');
            }

            stopwatch.Stop();

            //Console.WriteLine(builder.ToString());
            
            Console.WriteLine(stopwatch.ElapsedTicks);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
