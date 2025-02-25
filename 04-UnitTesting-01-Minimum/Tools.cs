using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_UnitTesting_01_Minimum
{
    public class Tools
    {
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 0)
            { 
                throw new ArgumentException("Empty set, cannot find minimum");
            }

            int min = int.MaxValue;

            foreach(int num in nums)
            {
                if (min > num)
                    min = num;
            }

            return min;
        }
    }
}
