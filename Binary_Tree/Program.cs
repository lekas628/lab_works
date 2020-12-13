using System;
using System.Collections.Generic;
using Tree;

namespace Program
{
    class Program
    {
        static private Random rand = new Random();

        static void Main(string[] args)
        {
            Node root = null;


            bool printOutput = true;

            int n = 5;
            int maxNumber = n;
            int maxElements = n;

            List<int> inputListSorted = new List<int>();
            List<int> CheckList = new List<int>();


            Console.WriteLine("INPUT");
            for (int i = 0; i < maxElements; i++)
            {
                int element = rand.Next() % maxNumber;

                root = Tree.Tree.Insert(root, element);
                inputListSorted.Add(element);
                if(printOutput)
                    Console.WriteLine(element);
            }
            inputListSorted.Sort();


            Console.WriteLine("SORTED INPUT LIST");
            foreach (int element in inputListSorted)
            { 
                if (printOutput)
                    Console.WriteLine(element);
            }


            Console.WriteLine("TREE PRINT AFTER FILL");
            int maxDeep = Tree.Tree.printTree(root, onlyGetMaxDeep: !printOutput);
            Console.WriteLine("\n");


            CheckList.Clear();
            Tree.Tree.InorderTraversal(root, CheckList);


            bool result = true;
            for (int i = 0; i < n; i++)
            {
                if (inputListSorted[i] != CheckList[i])
                    result = false;
            }
            Console.WriteLine(result);

            Console.WriteLine($"\n\nMAX DEEP IS {maxDeep}");
            Console.ReadKey();

        }
    }
}
