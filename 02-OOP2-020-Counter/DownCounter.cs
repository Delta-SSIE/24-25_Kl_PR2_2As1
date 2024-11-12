using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_020_Counter
{
    internal class DownCounter : StepCounter
    {
        private int initValue;

        public bool IsFinished => Count <= 0;

        public DownCounter(int step, int initValue) : base(-step)
        {
            this.initValue = initValue;
            Reset();
        }

        public override void Reset()
        {
            Count = initValue;
        }
    }
}
