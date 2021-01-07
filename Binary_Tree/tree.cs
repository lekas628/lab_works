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

        public static Node GetMin(Node node)
        {
            if (node == null)
                return null;
            Node left = node.leftChild;
            while(true)
            {
                if (left == null)
                    break;
                if (left.mark == 1)
                    break;
                node = node.leftChild;
                left = node.leftChild;
            }
            return node;
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
                node = InsertRoot(node, value);
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

            node = ClearFromErrors(node);
            fixSize(node);

            return node;
        }

        public static Node Insert(Node node, Node node1)
        {
            if (node1 == null)
                return node;
            if (node1.rightBrother != null)
                throw new Exception();
            
            if (node == null)
            {
                return node1;
            }
            if (node.mark == 1)
            {
                node1.rightBrother = node.rightBrother;
                node = node1;
                return node;
                //node.value = value;
                //node.mark = 0;
            }
            else if (node1.value <= node.value)
            {
                node.leftChild = Insert(node.leftChild, node1);
            }
            else
            {
                if (node.leftChild == null)
                {
                    node.leftChild = new Node(-1, mark: 1);
                }
                node.leftChild.rightBrother = Insert(node.leftChild.rightBrother, node1);
            }

            node = ClearFromErrors(node);
            fixSize(node);

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
            if (p == null)
                return p;

            Node q = p.leftChild;

            if (q == null)
                return p;
            if (q.mark == 1)
                return p;
            if (p.mark == 1)
                return p;

            Node pRightBrother = p.rightBrother;
            p.rightBrother = null;

            if (q.leftChild != null)
            {
                p.leftChild = q.leftChild.rightBrother;
                q.leftChild.rightBrother = null;
            }
            else
            {
                p.leftChild = null;
                q.leftChild = new Node(-1, 1);
            }

            if (q.rightBrother != null)
            {
                if (p.leftChild == null)
                    p.leftChild = new Node(-1, 1);
                p.leftChild.rightBrother = q.rightBrother;
                q.rightBrother = null;
            }

            q.leftChild.rightBrother = p;
            q.rightBrother = pRightBrother;

            fixSize(p);
            fixSize(q);

            return q;
        }



        public static Node rotateLeft(Node q)
        {
            if (q.leftChild == null)
                return null;
            if (q.leftChild.rightBrother == null)
                return null;

            Node p = q.leftChild.rightBrother;

            p.rightBrother = q.rightBrother;
            q.rightBrother = null;
            if (p.leftChild != null)
            {
                if (p.leftChild.rightBrother != null)
                {
                    q.rightBrother = p.leftChild.rightBrother;
                    p.leftChild.rightBrother = null;

                    if(p.leftChild.mark == 1)
                    {
                        q.leftChild.rightBrother = p.leftChild;
                        p.leftChild = null;
                    }

                }
                q.leftChild.rightBrother = p.leftChild;
                p.leftChild = null;
            }
            else
            {
                q.leftChild.rightBrother = null;
                if (q.leftChild.mark == 1)
                    q.leftChild = null;
            }

            p.leftChild = q;

            fixSize(q);
            fixSize(p);

          
            return p;
        }


        //public static Node Join(Node p, Node q)
        //{
        //    if (p == null)
        //        return q;
        //    if (q == null)
        //        return p;
        //    //if (p.mark == 1)
        //    //    return p.rightBrother;
        //    if (p.rightBrother == q)
        //        p.rightBrother = null;
        //    if (p.mark == 1)
        //        return q;


        //    if(rand.Next() % (p.size + q.size) < p.size)
        //    {
        //        if (p.leftChild == null)
        //            p.leftChild = new Node(-1, 1);
        //        p.leftChild.rightBrother = Join(p.leftChild.rightBrother, q);
        //        if (p.leftChild.rightBrother == null)
        //            if (p.leftChild.mark == 1)
        //                p.leftChild = null;
        //        fixSize(p);
        //        return p;
        //    }
        //    else
        //    {
        //        q.leftChild = Join(p, q.leftChild);
        //        fixSize(q);
        //        return q;
        //    }
        //}

        //public static Node Join(Node p, Node q)
        //{
        //    if (p == null)
        //        return q;
        //    if (q == null)
        //        return p;


        //    if (rand.Next() % (p.size + q.size) < p.size)
        //    {
        //        if(p.leftChild != null)
        //        {
        //            p.leftChild.rightBrother = Join(p.leftChild.rightBrother, q);
        //            fixSize(p);
        //            return p;
        //        }
        //        else
        //        {
        //            p.leftChild = Join(p.leftChild, q);
        //            fixSize(p);
        //            return p;
        //        }
        //    }
        //    else
        //    {
        //        if(q.leftChild == null)
        //        {
        //            q.leftChild = Join(p, q.leftChild);
        //            fixSize(q.leftChild);
        //            fixSize(q);
        //            return q;
        //        }
        //        else if(q.leftChild.mark == 1)
        //        {

        //        }
        //    }
        //}

        public static Node Remove(Node node, int value)
        {
            if (node == null)
                return node;
            if (node.mark == 1)
                return node;
            if (node.value == value)
            {
                Node rightBrother = node.rightBrother;
                if (node.leftChild == null)
                {
                    if (rightBrother != null)
                    {
                        node = new Node(-1, 1);
                        node.rightBrother = rightBrother;
                    }
                    else
                        node = null;
                    return node;
                }
                else if (node.leftChild.mark == 1)
                {
                    node = node.leftChild.rightBrother;
                    node.rightBrother = rightBrother;
                    return node;
                }
                else
                {
                    //Node rBbrother = node.leftChild.rightBrother;
                    //node.leftChild.rightBrother = null;

                    //node = Insert(node.leftChild, node.leftChild.rightBrother);
                    //// не забыть про правого брата исходного нода
                    //return node;
                    Node LSRB = node.leftChild.rightBrother;
                    node.leftChild.rightBrother = rightBrother;
                    node = node.leftChild;
                    node.leftChild = Insert(node.leftChild, LSRB);
                    return node;
                }
            }
            else if (value <= node.value)
            {
                node.leftChild = Remove(node.leftChild, value);
                return node;
            }
            else
            {
                if (node.leftChild != null)
                {
                    node.leftChild.rightBrother = Remove(node.leftChild.rightBrother, value);
                    return node;
                }
                else
                {
                    return node;
                }
            }

        }
        
        public static Node ClearFromErrors(Node node)
        {
            if (node == null)
                return node;
            if (node.leftChild == null)
                return node;
            if (node.leftChild != null)
                if (node.leftChild.mark == 1)
                    if (node.leftChild.rightBrother == null)
                    {
                        node.leftChild = null;
                        return node;
                    }
            node.leftChild = ClearFromErrors(node.leftChild);
            node.leftChild.rightBrother = ClearFromErrors(node.leftChild.rightBrother);
            return node;
        }
        //public static Node Remove(Node node, int value)
        //{
        //    if (node == null)
        //        return null;
        //    if (node.mark != 0)
        //        return null;

        //}




        //static public int printTree(Node node, int prefixNumber = 0, bool isRoot = false, int mark = 0, bool onlyGetMaxDeep = false)
        //{
        //    if (node == null)
        //        return 0;

        //    int maxDeep = prefixNumber;
        //    if(node.leftChild != null)
        //    {
        //        int leftDeep = printTree(node.leftChild, prefixNumber + 1, onlyGetMaxDeep: onlyGetMaxDeep);
        //        if (maxDeep < leftDeep) { maxDeep = leftDeep; }
        //    }

        //    string output = $"NODE HASH({node.GetHashCode()})";

        //    if (node.mark == 1)
        //        output += $" VIRTUAL";
        //    else
        //        output +=  $" VALUE({node.value})";


        //    int prefixCounter = 0;
        //    while (prefixCounter <= prefixNumber)
        //    {
        //        output = "+" + output;
        //        prefixCounter++;
        //    }

        //    output = $"{prefixNumber}\t" + output;
        //    if(!onlyGetMaxDeep)
        //        Console.WriteLine(output);

        //    if(node.leftChild != null)
        //    {
        //        if(node.leftChild.rightBrother != null)
        //        {
        //            int rightDeep = printTree(node.leftChild.rightBrother, prefixNumber + 1, onlyGetMaxDeep: onlyGetMaxDeep);
        //            if (maxDeep < rightDeep) { maxDeep = rightDeep; }
        //        }
        //    }
        //    return maxDeep;
        //}

        static public int getMaxDeep(Node node, int curDeep = 0)
        {
            if (node == null)
                return 0;

            int maxDeep = curDeep;
            if (node.leftChild != null)
            {
                int leftDeep = getMaxDeep(node.leftChild, curDeep + 1);
                if (maxDeep < leftDeep) { maxDeep = leftDeep; }
            }

            if (node.leftChild != null)
            {
                if (node.leftChild.rightBrother != null)
                {
                    int rightDeep = getMaxDeep(node.leftChild.rightBrother, curDeep + 1);
                    if (maxDeep < rightDeep) { maxDeep = rightDeep; }
                }
            }
            return maxDeep;
        }
        //static public int printTree(Node node, int prefixNumber = 0, bool isRoot = true, int side = 0, int mark = 0, bool onlyGetMaxDeep = false)
        //{
        //    if (node == null)
        //        return 0;

        //    int maxDeep = getMaxDeep(node);
          
            
        //    return maxDeep;
        //}

        public static int printTree(Node node, String indent = "", bool onlyGetMaxDeep = false)
        {
            if (node == null)
            {
                Console.WriteLine("TREE IS EMPTY");
                return 0;
            }
            string indexForThis = indent.Substring(0, indent.Length);
            indent +=  "|  ";


            if (node.leftChild != null)
                if (node.leftChild.rightBrother != null)
                    printTree(node.leftChild.rightBrother, indent);
            
            
            if(node.mark == 1)
                Console.WriteLine(indexForThis + "+- " + "V");
            else
                Console.WriteLine(indexForThis + "+- " + node.value);
            //indent += "|  ";


            if(node.leftChild != null)
                printTree(node.leftChild, indent);
            
            
            return getMaxDeep(node);
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