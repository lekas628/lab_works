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
            //List<int> output = new List<int>();
            //List<int> input = new List<int>() { 3,3,4,3,0};
            //Node root = null;

            //foreach (int element in input)
            //    root = Tree.Tree.Insert(root, element);

            ////root = new Node(0);
            ////root.leftChild = new Node(0);
            ////root.leftChild.leftChild = new Node(0);
            ////root.leftChild.rightBrother = new Node(4);
            ////root.leftChild.rightBrother.leftChild = new Node(4);


            ////root = Tree.Tree.Remove(root, 4);
            //int maxDeep = Tree.Tree.printTree(root);

            //Tree.Tree.InorderTraversal(root, output);

            //input.Remove(4);
            //CheckTree(input, output);

            for(int i = 0; i < 10; i++)
                run();
            
            Console.ReadKey();
        }

        static void CheckTree(List<int> input, List<int> treeOutput)
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
            Console.WriteLine(result);
        }

        static void run()
        {

            Node root = null;


            bool printOutput = false;

            int n = 100;
            int maxNumber = n;
            int maxElements = n;

            List<int> inputListSorted = new List<int>();
            List<int> CheckList = new List<int>();

            if(printOutput)
                Console.WriteLine("INPUT");
            for (int i = 0; i < maxElements; i++)
            {
                int element = rand.Next() % maxNumber;
                inputListSorted.Add(element);
                if (printOutput)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"ADD ELEMENT {element}");
                    Console.Write("must be in list ");
                    foreach (int elem in inputListSorted)
                        Console.Write($"{elem} ");
                    Console.WriteLine("\n");
                }

                root = Tree.Tree.Insert(root, element);
            }
            inputListSorted.Sort();

            if(printOutput)
                Console.WriteLine("SORTED INPUT LIST");
            foreach (int element in inputListSorted)
            {
                if (printOutput)
                    Console.WriteLine(element);
            }

            if(printOutput)
                Console.WriteLine("TREE PRINT AFTER FILL");
            int maxDeep = Tree.Tree.printTree(root, onlyGetMaxDeep: !printOutput);
            Console.WriteLine("\n");




            //Console.WriteLine($"REMOVE ELEMENT {inputListSorted[3]}");
            //Tree.Tree.Remove(root, inputListSorted[3]);
            //Tree.Tree.printTree(root);
            //inputListSorted.Remove(inputListSorted[3]);



            CheckList.Clear();
            Tree.Tree.InorderTraversal(root, CheckList);


            bool result = true;
            for (int i = 0; i < inputListSorted.Count - 1; i++)
            {
                if (inputListSorted[i] != CheckList[i])
                {
                    result = false;
                }
            }
            if (inputListSorted.Count != CheckList.Count)
                result = false;
            
            Console.WriteLine($"RESULT\t\t{result}");

            Console.WriteLine($"\nMAX DEEP IS {maxDeep}");
            Console.WriteLine($"ROOT SIZE IS {root.size}");
            if (printOutput)
                Console.ReadKey();
        }
    }

}
