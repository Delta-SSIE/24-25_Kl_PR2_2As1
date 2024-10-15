namespace _01_OOP_090_String_a_ref_val
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";
            ModifyStr(text);
            Console.WriteLine(text);
        }

        static void ModifyStr(string str)
        {
            str += "!";
        }
    }
}
