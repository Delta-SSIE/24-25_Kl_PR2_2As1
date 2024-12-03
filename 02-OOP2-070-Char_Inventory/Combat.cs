using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Combat
    {
        public Character Fighter1;
        public Character Fighter2;
        public IReporter Reporter;

        public void Fight()
        {
            int n = 1;
            // dokud oba ziji
            while (Fighter1.IsAlive && Fighter2.IsAlive)
            {
                Reporter.Report($"{n}. kolo");
                Reporter.Report($"{Fighter1.Name} : {Fighter1.Health} , {Fighter2.Name} : {Fighter2.Health}");
                Round(); // odehrajte kolo
                Reporter.Separate();
                n++;
            }

            if (Fighter1.IsAlive)
            {
                Reporter.Report($"{Fighter1.Name} vítězí, {Fighter2.Name} leží v krvi");
            }
            else
            {
                Reporter.Report($"{Fighter2.Name} vítězí, {Fighter1.Name} leží v krvi");
            }
        }

        public void Round()
        {
            // zjisti iniciativu
            Character first = null, second = null;

            while (first is null)
            {
                int roll1 = Fighter1.InitiativeRoll();
                int roll2 = Fighter2.InitiativeRoll();

                if (roll1 > roll2)
                    (first, second) = (Fighter1, Fighter2);
                else if (roll2 > roll1)
                    (first, second) = (Fighter2, Fighter1);
            }

            // jeden utoci druhy se brani
            Exchange(first, second);

            // pak naopak
            if (second.IsAlive)
                Exchange(second, first);
        }

        public void Exchange(Character attacker, Character defender)
        {
            (int attack, int damage) = attacker.AttackRoll();
            int defense = defender.DefenseRoll();
            if (defense >= attack)
            {
                //ubranil se
                Reporter.Report($"{defender.Name} má hod {defense} a ubránil se útoku {attacker.Name} s hodem {attack}");
            }
            else
            {
                int wound = attack - defense + damage;
                if (wound < 0)
                    wound = 0;

                defender.DecreaseHealth(wound);
                Reporter.Report($"{attacker.Name} útočí na {defender.Name} a s hodem ({attack}, {damage}) proti {defense} mu působí zranění {wound}.");
            } 
        }

    }
}
