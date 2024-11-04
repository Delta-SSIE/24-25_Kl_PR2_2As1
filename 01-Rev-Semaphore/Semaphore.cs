using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Rev_Semaphore
{
    internal class Semaphore
    {
        private bool isOn = true;
        private int phase = 0;

        public int Cycles { get; private set; } = 0;
        public bool Red    => isOn && phase == 0;
        public bool Orange => (isOn && (phase == 1 || phase == 3)) || (!isOn && phase == 1);
        public bool Green  => isOn && phase == 2;

        public void Toggle()
        {
            isOn = !isOn;
            phase = 0;

            if (isOn)
                Cycles = 0;
        }

        public void NextState()
        {
            phase++;
            if (isOn && phase > 3)
            {
                phase = 0;
                Cycles++;
            }
            else if (!isOn && phase > 1)
            {
                phase = 0;
            }
        }
    }
}
