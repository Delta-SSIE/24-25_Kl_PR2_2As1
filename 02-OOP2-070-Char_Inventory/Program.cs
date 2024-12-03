namespace _02_OOP2_070_Char_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character Bob = new Character("Bob", 60, 60);
            Character Cid = new Character("Cid", 50, 60);

            Bob.Equip(new Weapon("Obouruční sekera", 20, 3, 6, true));
            Bob.Equip(new Armor("Kožené brnění", 30, 2));

            Cid.Equip(new Weapon("Dlouhý meč", 10, 0, 6, false));
            Cid.Equip(new Shield("Velký štít", 10, 2));
            Cid.Equip(new Armor("Kroužková zbroj", 25, 4));

            Combat combat = new Combat();
            combat.Fighter1 = Bob;
            combat.Fighter2 = Cid;
            combat.Reporter = new ConsoleReporter();

            combat.Fight();

        }
    }
}
