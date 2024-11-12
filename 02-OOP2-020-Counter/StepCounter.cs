using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_020_Counter
{
    internal class StepCounter : Counter
    {
        private int step;

        public StepCounter(int step)
        {
            this.step = step;
        }

        public override void Next()
        {
            Count += step;
        }
    }
}
