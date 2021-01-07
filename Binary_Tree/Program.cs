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
            runTask();
            //run();
            Console.ReadKey();
        }

        static bool CheckTree(List<int> input, List<int> treeOutput)
        {
            bool result = true;
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] != treeOutput[i])
                {
                    result = false;
                }
            }
            if (input.Count != treeOutput.Count)
                result = false;
            return result;
        }

        static void run()
        {
            bool printOutput = false;

            Node rootA = null;

            int nA = 100;
            int maxNumberA = nA;
            int maxElementsA = nA;

            List<int> inputListSortedA = new List<int>();
            List<int> CheckListA = new List<int>();

            if(printOutput)
                Console.WriteLine("INPUT");
            for (int i = 0; i < maxElementsA; i++)
            {
                int element = rand.Next() % maxNumberA;
                inputListSortedA.Add(element);
                if (printOutput)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"ADD ELEMENT {element}");
                    Console.Write("must be in tree ");
                    foreach (int elem in inputListSortedA)
                        Console.Write($"{elem} ");
                    Console.WriteLine("\n");
                }

                rootA = Tree.Tree.Insert(rootA, element);
            }
            inputListSortedA.Sort();
            
            CheckListA.Clear();
            Tree.Tree.InorderTraversal(rootA, CheckListA);
            bool fillResultA = CheckTree(inputListSortedA, CheckListA);
            
            Console.Write($"RESULT A {fillResultA}");
            Console.WriteLine($"\t\tROOT A SIZE IS {rootA.size}");




            Node rootB = null;

            int nB = 20;
            int maxNumberB = nA;
            int maxElementsB = nB;

            List<int> inputListSortedB = new List<int>();
            List<int> CheckListB = new List<int>();

            if (printOutput)
                Console.WriteLine("INPUT");
            for (int i = 0; i < maxElementsB; i++)
            {
                int element = rand.Next() % maxNumberA;
                inputListSortedB.Add(element);
                if (printOutput)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"ADD ELEMENT {element}");
                    Console.Write("must be in tree ");
                    foreach (int elem in inputListSortedB)
                        Console.Write($"{elem} ");
                    Console.WriteLine("\n");
                }

                rootB = Tree.Tree.Insert(rootB, element);
            }
            inputListSortedB.Sort();

            CheckListB.Clear();
            Tree.Tree.InorderTraversal(rootB, CheckListB);
            bool fillResultB = CheckTree(inputListSortedB, CheckListB);

            Console.Write($"RESULT B {fillResultA}");
            Console.WriteLine($"\t\tROOT B SIZE IS {rootB.size}");



            while (rootB != null)
            {
                if (rootB.mark == 1)
                    break;
                int bMin = Tree.Tree.GetMin(rootB).value;
                rootB = Tree.Tree.Remove(rootB, bMin);
                
                rootA = Tree.Tree.Remove(rootA, bMin);
                inputListSortedA.Remove(bMin);
            }

            CheckListA.Clear();
            Tree.Tree.InorderTraversal(rootA, CheckListA);
            bool result = CheckTree(inputListSortedA, CheckListA);
            Console.WriteLine($"RESULT {result}");

        }
    
        
        static void runTask()
        {
            Node rootA = null;
            Node rootB = null;

            int[] firstTreeArr = { 2, 4, 14, 2, 7, 8, 12 };
            int[] secondTreeArr = { 2, 4, 5 };

            //int[] firstTreeArr = { 1, 7, 2, 4, 1, 14, 32, 16, 55, 120 };
            //int[] secondTreeArr = { 14, 5, 21, 32, 55, 666 };



            foreach (int number in firstTreeArr)
            {
                rootA = Tree.Tree.Insert(rootA, number);
            }
            foreach(int number in secondTreeArr)
            {
                rootB = Tree.Tree.Insert(rootB, number);
            }

            Console.WriteLine("TREE A");
            Tree.Tree.printTree(rootA);
            Console.WriteLine("Обратный обход");
            Tree.Tree.PostorderTraversal(rootA);


            Console.WriteLine("TREE B");
            Tree.Tree.printTree(rootB);
            Console.WriteLine("Симметричный обход");
            Tree.Tree.InorderTraversal(rootB);

            Node rootC = null;

            while (rootB != null)
            {
                if (rootB.mark == 1)
                    break;
                int bMin = Tree.Tree.GetMin(rootB).value;
                
                rootB = Tree.Tree.Remove(rootB, bMin);
                rootA = Tree.Tree.Remove(rootA, bMin);

                rootC = Tree.Tree.Insert(rootC, bMin);
                //Console.WriteLine($"REMOVING {bMin}");
                //Tree.Tree.printTree(rootA, indent: "DEBUG A");
                //Console.WriteLine("\n");

                //Tree.Tree.printTree(rootB, indent: "DEBUG B");
                //Console.WriteLine("\n\n");

            }

   

            while(rootC != null)
            {
                //if (rootC.mark == 1)
                //    break;
                int cMin = Tree.Tree.GetMin(rootC).value;
                rootC = Tree.Tree.Remove(rootC, cMin);
                rootB = Tree.Tree.Insert(rootB, cMin);
            }

            Console.WriteLine("NEW TREE A");
            Tree.Tree.printTree(rootA);

            //Console.WriteLine("OLD TREE B");
            //Tree.Tree.printTree(rootB);

        }
    }
}
