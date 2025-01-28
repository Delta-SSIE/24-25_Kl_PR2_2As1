using System.Xml.Linq;
using System;

namespace _03_Data_03_Obchodnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "smalltree.json";
            //string filename = "largetree.json";
            Salesman boss = Salesman.DeserializeTree(File.ReadAllText(filename));

            DisplaySalesmenTree(boss);
            FindByNameQueue(boss, "Brown");

            Salesman brown = GetByNameQueue(boss, "Brown")[0];
            Console.WriteLine(GetTotalSalesStack(boss));
            Console.WriteLine(GetTotalSalesStack(brown));
            Console.WriteLine(GetTotalSalesStack(GetByNameQueue(boss, "Jackson")[0]));

            Console.WriteLine(GetTotalSalesRecursive(boss));
            Console.WriteLine(GetTotalSalesRecursive(brown));
            Console.WriteLine(GetTotalSalesRecursive(GetByNameQueue(boss, "Jackson")[0]));
        }
        static void DisplaySalesmenTree(Salesman node, string indent = "")
        {
            Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                DisplaySalesmenTree(subordinate, indent + "    ");
            }
        }

        static void FindByNameRecursive(Salesman node, string name)
        {
            if (node.Surname == name)
                Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                FindByNameRecursive(subordinate, name);
            }
        }
        static void FindByNameStack(Salesman root, string name)
        {
            Stack<Salesman> toBeVisited = new Stack<Salesman>();
            toBeVisited.Push(root);

            while (toBeVisited.Count > 0) {
                Salesman node = toBeVisited.Pop();
            
                if (node.Surname == name)
                    Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

                foreach (var subordinate in node.Subordinates)
                {
                    toBeVisited.Push(subordinate);
                }
            }
        }
        static void FindByNameQueue(Salesman root, string name)
        {
            Queue<Salesman> toBeVisited = new Queue<Salesman>();
            toBeVisited.Enqueue(root);

            while (toBeVisited.Count > 0)
            {
                Salesman node = toBeVisited.Dequeue();

                if (node.Surname == name)
                    Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

                foreach (var subordinate in node.Subordinates)
                {
                    toBeVisited.Enqueue(subordinate);
                }
            }
        }
        static Salesman[] GetByNameQueue(Salesman root, string name)
        {
            List<Salesman> found = new List<Salesman>();

            Queue<Salesman> toBeVisited = new Queue<Salesman>();
            toBeVisited.Enqueue(root);

            while (toBeVisited.Count > 0)
            {
                Salesman node = toBeVisited.Dequeue();

                if (node.Surname == name)
                    found.Add(node);

                foreach (var subordinate in node.Subordinates)
                {
                    toBeVisited.Enqueue(subordinate);
                }
            }

            return found.ToArray();
        }

        static int GetTotalSalesStack(Salesman root)
        {
            int total = 0;

            Stack<Salesman> toBeVisited = new Stack<Salesman>();
            toBeVisited.Push(root);

            while (toBeVisited.Count > 0)
            {
                Salesman node = toBeVisited.Pop();
                total += node.Sales;

                foreach (var subordinate in node.Subordinates)
                {
                    toBeVisited.Push(subordinate);
                }
            }

            return total;
        }

        static int GetTotalSalesRecursive(Salesman root)
        {
            int sum = root.Sales;
            foreach (var sub in root.Subordinates)
                sum += GetTotalSalesRecursive(sub);
            return sum;
        }

    }
}
