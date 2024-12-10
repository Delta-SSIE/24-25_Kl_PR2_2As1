using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_060_Iface_Utvary
{
    internal interface IUtvar
    {
        string Nazev { get; } //iface - vše automaticky veřejné
        double GetObvod();
        double GetObsah();
    }
}
