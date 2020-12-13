using System;
using System.Collections.Generic;

namespace Tree
{
    static class Tree
    {

        public static Random rand = new Random();

        public static Node Find(Node node, int value)
        {
            if (node == null || node.mark == 1)
                return null;
            if(value <= node.value)
            {
                return Find(node.leftChild, value);
            }
            else
            {
                if (node.leftChild != null)
                    return Find(node.leftChild.rightBrother, value);
                else
                    return null;
            }
        }
        public static Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }
            if (node.mark == 1)
            {
                node.value = value;
                node.mark = 0;
            }
            else if (rand.Next() % (node.size + 1) == 0)
            {
                return InsertRoot(node, value);
            }
            else if (value <= node.value)
            {
                node.leftChild = Insert(node.leftChild, value);
            }
            else
            {
                if (node.leftChild == null)
                {
                    node.leftChild = new Node(-1, mark: 1);
                }
                node.leftChild.rightBrother = Insert(node.leftChild.rightBrother, value);
            }
            return node;
        }

        static public Node InsertRoot(Node node, int value)
        {
            if (node == null) return new Node(value);
            if (node.mark == 1)
            {
                node.value = value;
                node.mark = 0;
                return node;
            }
            else if (value <= node.value)
            {
                node.leftChild = InsertRoot(node.leftChild, value);
                return rotateRight(node);
            }
            else
            {
                if (node.leftChild == null)
                {
                    node.leftChild = new Node(-1, mark: 1);
                }
                node.leftChild.rightBrother = InsertRoot(node.leftChild.rightBrother, value);
                return rotateLeft(node);
            }
        }


        public static Node rotateRight(Node p)
        {
            Node q = p.leftChild;
            if (q == null || q.mark == 1)
                return p;

            Node pRightBrother = p.rightBrother;
            if(q.leftChild == null)
            {
                q.leftChild = new Node(-1, mark: 1);
            }
            if(q.leftChild.rightBrother == null)
            {
                q.leftChild.rightBrother = new Node(-1, mark: 1);
            }
            
            p.leftChild = q.leftChild.rightBrother;
            p.leftChild.rightBrother = q.rightBrother;
            p.rightBrother = null;

            q.rightBrother = pRightBrother;
            q.leftChild.rightBrother = p;

            fixSize(p);
            fixSize(q);

            return q;
        }

        public static Node rotateLeft(Node q)
        {
            if (q.leftChild == null)
                return q;
            if (q.leftChild.rightBrother == null)
                return q;

            Node p = q.leftChild.rightBrother;
            p.rightBrother = q.rightBrother;
            
            if (p.leftChild != null)
            {
                q.rightBrother = p.leftChild.rightBrother;
                p.leftChild.rightBrother = null;
                q.leftChild.rightBrother = p.leftChild;
            }
            else
            {
                q.rightBrother = null;
                q.leftChild.rightBrother = null;
            }
            
            p.leftChild = q;

            fixSize(q);
            fixSize(p);

            return p;
        }

        static public int printTree(Node node, int prefixNumber = 0, bool isRoot = false, int mark = 0, bool onlyGetMaxDeep = false)
        {
            if (node == null)
                return 0;

            int maxDeep = prefixNumber;
            if(node.leftChild != null)
            {
                int leftDeep = printTree(node.leftChild, prefixNumber + 1, onlyGetMaxDeep: onlyGetMaxDeep);
                if (maxDeep < leftDeep) { maxDeep = leftDeep; }
            }
            
            string output = $"NODE HASH({node.GetHashCode()})";

            if (node.mark == 1)
                output += $" VIRTUAL";
            else
                output +=  $" VALUE({node.value})";
            
            
            //if(isRoot) { output = "ROOT" + output; }

            int prefixCounter = 0;
            while (prefixCounter < prefixNumber)
            {
                output = "+" + output;
                prefixCounter++;
            }
            output = $"{prefixNumber}\t" + output;
            if(!onlyGetMaxDeep)
                Console.WriteLine(output);

            if(node.leftChild != null)
            {
                if(node.leftChild.rightBrother != null)
                {
                    int rightDeep = printTree(node.leftChild.rightBrother, prefixNumber + 1, onlyGetMaxDeep: onlyGetMaxDeep);
                    if (maxDeep < rightDeep) { maxDeep = rightDeep; }
                }
            }
            return maxDeep;
        }

        static public int getSize(Node node)
        {
            if (node == null) return 0;
            if (node.mark == 1) return 0;
            else
                return node.size;
        }
        static public void fixSize(Node node)
        {
            int lSize = getSize(node.leftChild);
            int rSize = 0;
            if (node.leftChild != null)
                rSize = getSize(node.leftChild.rightBrother);
            node.size = lSize + rSize + 1;
        }


        public static void InorderTraversal(Node node)
        {
            if (node == null)
                return;
            if (node.mark != 0)
                return;
            
            InorderTraversal(node.leftChild);
                
            Console.WriteLine(node.value);
                
            if (node.leftChild != null)
                InorderTraversal(node.leftChild.rightBrother);
        }

        public static void InorderTraversal(Node node, List<int> outputList)
        {
            if (node == null)
                return;
            if (node.mark != 0)
                return;

            InorderTraversal(node.leftChild, outputList);

            outputList.Add(node.value);

            if (node.leftChild != null)
                InorderTraversal(node.leftChild.rightBrother, outputList);
        }

        public static void PostorderTraversal(Node node)
        {
            if (node == null)
                return;
            if (node.mark != 0)
                return;

            PostorderTraversal(node.leftChild);
            if (node.leftChild != null)
                PostorderTraversal(node.leftChild.rightBrother);
            Console.WriteLine(node.value);
        }

        public static void PostorderTraversal(Node node, List<int> outputList)
        {
            if (node == null)
                return;
            if (node.mark != 0)
                return;

            PostorderTraversal(node.leftChild);
            if (node.leftChild != null)
                PostorderTraversal(node.leftChild.rightBrother);
            outputList.Add(node.value);
        }
    }
    class Node
    {
        public int value;
        public Node leftChild;
        public Node rightBrother;
        public int mark;
        public int size;

        public Node(int value, int mark = 0)
        {
            this.value = value;
            this.leftChild = null;
            this.rightBrother = null;
            this.mark = mark;

            if (this.mark == 0)
                this.size = 1;
            else 
                this.size = 0;
        }

        public override string ToString()
        {
            if (this == null)
                return "null";
            else
                return $"{value}";
        }

        public string ToString(bool _)
        {
            return $"NODE HASH({this.GetHashCode()}) VALUE({this.value}) LEFTCHILD({this.leftChild}) RIGHTBROTHER({this.leftChild.rightBrother})";
        }
    }

}