namespace _02_OOP2_Iface_ICloneable_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = [1, 2, 3];
            int[] intsCopy = (int[])ints.Clone();
            //int[] intsCopy = [..ints]; //vždy mělká kopie


            
        }
    }

    class Vec : ICloneable
    {
        public string Jmeno { get; set; }
        public Vec? Rodic { get; set; }

        public object Clone()
        {
            Vec klon = new Vec();
            klon.Jmeno = this.Jmeno;
            //klon.Rodic = this.Rodic; //melka kopie - bude reference na puvodniho rodice
            klon.Rodic = (Vec)this.Rodic.Clone(); //hluboka kopie - bude klonovan i puvodni rodic a jeho rodic ...
            return klon;
        }
    }
}
