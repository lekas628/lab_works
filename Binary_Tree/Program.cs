using System;
using Another_Tree;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            AnotherTree tree = new AnotherTree(50);


            // BinaryTree tree = new BinaryTree(50);
            // tree.insertNode(45);
            // tree.insertNode(55);
            // Console.WriteLine("info about root");
            // PrintNodeInformationCompact(tree.Root);
            
            // tree.insertNode(30);
            // tree.insertNode(47);
            // Console.WriteLine("info about left son");
            // PrintNodeInformationCompact(tree.Root.LeftSon);

            // tree.insertNode(57);
            // Console.WriteLine("info about right son");
            // PrintNodeInformationCompact(tree.Root.RightSon);
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
