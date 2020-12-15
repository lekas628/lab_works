using System;
using System.Collections.Generic;

namespace Tree
{
    static class Tree
    {

        public static Random rand = new Random();
        static public bool debug = false;
        static public bool debug_1 = false; // дебаг поворотов
        static public bool debug_2 = false; // отрисовка деревьев во время дебага
        static public int debugTmp1;
        static public int debugTmp2;
        

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
            fixSize(node);

            if(debug_2)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"PRINT TREE AFTER INSERT {value}");
                Tree.printTree(node);
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
            if (p == null)
                return p;

            Node q = p.leftChild;

            if (q == null)
                return p;
            if (q.mark == 1)
                return p;
            if (p.mark == 1)
                return p;

            if(debug_2)
            {
                Console.WriteLine("\n");
                Console.WriteLine("rotate right print tree BEFORE rotate");
                Tree.printTree(p);
            }

            if(debug_1)
            {
                debugTmp1 = p.leftChild.size;
                debugTmp2 = 0;
                if(p.leftChild.rightBrother != null)
                    debugTmp2 = p.leftChild.rightBrother.size;
            }


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

            if(debug_1)
                Console.WriteLine($"Rotate right left({debugTmp1}) right({debugTmp2}) sum({debugTmp1 + debugTmp2})");
            if (debug_2)
            {
                Console.WriteLine("\n");
                Console.WriteLine("rotate right print tree AFTER rotate");
                Tree.printTree(p);
            }


            return q;
        }



        public static Node rotateLeft(Node q)
        {
            if (q.leftChild == null)
                return null;
            if (q.leftChild.rightBrother == null)
                return null;

            Node p = q.leftChild.rightBrother;

            if(debug_1)
            {
                debugTmp1 = q.leftChild.size;
                debugTmp2 = q.leftChild.rightBrother.size;
            }

            if (debug_2)
            {
                Console.WriteLine("\n");
                Console.WriteLine("rotate left print tree BEFORE rotate");
                Tree.printTree(p);
            }

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

            if(debug_1)
                Console.WriteLine($"Rotate left left({debugTmp1}) right({debugTmp2}) sum({debugTmp1 + debugTmp2})");
            if (debug_2)
            {
                Console.WriteLine("\n");
                Console.WriteLine("rotate left print tree AFTER rotate");
                Tree.printTree(p);
            }


            return p;

        }

  
        //public static Node Join(Node p, Node q)
        //{
        //    if (p == null)
        //        return q;
        //    if (q == null)
        //        return p;
        //    if (p.rightBrother == q)
        //        p.rightBrother = null;

        //    if (rand.Next() % (p.size + q.size) < p.size)
        //    {
        //        if(p.leftChild == null)
        //            p.leftChild = new Node(-1, mark: 1);
        //        p.leftChild.rightBrother = Join(p.leftChild.rightBrother, q);
        //        fixSize(p);
        //        return p;
        //    }
        //    else
        //    {
        //        if(q.leftChild != null)
        //        {
        //            if(q.leftChild.mark == 1)
        //            {
        //                q.leftChild.value = p.value;
        //                q.leftChild = p.leftChild;
        //                q.mark = 0;
        //                fixSize(q);
        //                return q;
        //            }

        //        }
        //        q.leftChild = Join(p, q.leftChild);


        //        fixSize(p);
        //        fixSize(q);

        //        return q;
        //    }
        //}

        //public static Node Remove(Node node, int value)
        //{
        //    if (node == null)
        //        return node;
        //    if (node.mark == 1)
        //        return node;

        //    if (node.value == value)
        //    {
        //        if (node.leftChild != null)
        //        {
        //            if(node.leftChild.mark == 1)
        //            {
        //                node.leftChild.rightBrother.rightBrother = node.rightBrother;
        //                node = node.leftChild.rightBrother;
        //                return node;
        //            }
        //            if(node.leftChild.rightBrother == null)
        //            {
        //                node.leftChild.rightBrother = node.rightBrother;
        //                node = node.leftChild;
        //                return node;
        //            }
        //            //Node tmp = Join(node.leftChild, node.leftChild.rightBrother);
        //            //node = null;
        //            node = Join(node.leftChild, node.leftChild.rightBrother);
        //            return node;
        //        }
        //        else
        //        {
        //            return null;
        //            //else
        //            //{
        //            //    node.value = -1;
        //            //    node.mark = 1;
        //            //    return node;
        //            //}
        //        }
        //    }
        //    else if (value < node.value)
        //    {
        //        node.leftChild = Remove(node.leftChild, value);
        //        return node;
        //    }
        //    else
        //    {
        //        if(node.leftChild != null)
        //        {
        //            node.leftChild.rightBrother = Remove(node.leftChild.rightBrother, value);
        //            return node;
        //        }
        //        else
        //        {
        //            return node;
        //        }
        //    }

        //}

        //node* remove(node* p, int k) // удаление из дерева p первого найденного узла с ключом k 
        //{
        //    if (!p) return p;
        //    if (p->key == k)
        //    {
        //        node* q = join(p->left, p->right);
        //        delete p;
        //        return q;
        //    }
        //    else if (k < p->key)
        //        p->left = remove(p->left, k);
        //    else
        //        p->right = remove(p->right, k);
        //    return p;
        //}

        //public static Node Remove(Node node, int value)
        //{
        //    if (node == null)
        //        return null;
        //    if (node.mark != 0)
        //        return null;

        //}




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
            while (prefixCounter <= prefixNumber)
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