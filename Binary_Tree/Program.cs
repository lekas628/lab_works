using System;
using Tree;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Binary_Tree tree = new Binary_Tree(50);
            
            tree.addNode(45);
            tree.addNode(55);
            PrintNodeInformationCompact(tree.Root);
            
            tree.addNode(30);
            tree.addNode(47);
            PrintNodeInformationCompact(tree.Root.LeftSon);

            tree.addNode(57);
            PrintNodeInformationCompact(tree.Root.RightSon);
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
