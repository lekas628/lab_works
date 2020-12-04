using System;
using Another_Tree;

namespace Program
{
    class Program
    {
        static private Random rand = new Random();

        static void Main(string[] args)
        {
            
            Node root = null;

            //for (int i = 0; i < 40; i++)
            //    root = AnotherTree.insertNode(root, rand.Next() % 100);

            int n = 1500;
            int max_number = n;
            int elements = n;
            
            for (int i = 0; i < elements; i++)
                root = AnotherTree.insertNode(root, rand.Next() % max_number);



            //root = AnotherTree.insertNode(root, 65);
            //root = AnotherTree.insertNode(root, 35);
            //root = AnotherTree.insertNode(root, 75);

            //PrintNodeInformationCompact(root);
            //PrintNodeInformationCompact(root.LeftSon);
            //PrintNodeInformationCompact(root.RightSon);
            int max_deep = AnotherTree.printTree(root, isRoot: true);
            Console.WriteLine($"\n\nMAX DEEP IS {max_deep}");


        }
        static void PrintNodeInformation(Node node)
        {
            if(node == null)
            {
                Console.WriteLine("Null node");
                return;
            }
            String text = $"Node with hash {node.GetHashCode()} and value {node.Value} has ";
            
            if((node.LeftSon != null) && (node.RightSon != null))
            {
                text += $"left son {node.LeftSon.Value} and right son {node.RightSon.Value}";
            }
            else if(node.LeftSon != null)
            {
                text += $"left son {node.LeftSon.Value}";
            }
            else if(node.RightSon != null)
            {
                text += $"right son {node.RightSon.Value}";
            }
            Console.WriteLine(text);
        }
        
        static void PrintNodeInformationCompact(Node node)
        {
            if(node == null)
            {
                Console.WriteLine("Null node");
                return;
            }
            String text = $"NODE HASH({node.GetHashCode()}) VALUE({node.Value}) ";
            
            if((node.LeftSon != null) && (node.RightSon != null))
            {
                text += $"LEFT({node.LeftSon.Value}) RIGHT({node.RightSon.Value})";
            }
            else if(node.LeftSon != null)
            {
                text += $"LEFT({node.LeftSon.Value})";
            }
            else if(node.RightSon != null)
            {
                text += $"RIGHT({node.RightSon.Value})";
            }
            Console.WriteLine(text);
        }
    }
}
