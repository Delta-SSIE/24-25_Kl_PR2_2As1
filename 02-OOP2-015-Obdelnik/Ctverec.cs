﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_015_Obdelnik
{
    internal class Ctverec : Obdelnik
    {
        public Ctverec(double strana) : base(strana, strana)
        {
        }

        public override string ToString()
        {
            return $"Čtverec o straně {StranaA}";
        }
    }
}
