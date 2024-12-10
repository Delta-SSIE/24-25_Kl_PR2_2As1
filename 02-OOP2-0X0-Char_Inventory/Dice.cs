using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Dice
    {
        private static Random random;

        private static Random GetRandom()
        {
            if (random is null)
                random = new Random();

            return random;
        }


        public int Sides;

        public Dice(int sides = 6)
        {
            Sides = sides;
        }

        public int Roll()
        {
            Random rnd = GetRandom();
            return rnd.Next(Sides) + 1;
        }

        public int CumulativeRoll()
        {
            Random rnd = GetRandom();
            int total = 0;
            while (true)
            {
                int roll = Roll();
                total += roll;
                if (roll != 6)
                    return total;
            }
            
        }
    }
}
