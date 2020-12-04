using System;

namespace Another_Tree
{
    class AnotherTree
    {
        static private Random rand = new Random();

        static public Node findNode(Node p, int value)
        {
            if (p == null)
            {
                return p;
            }
            if (value < p.Value)
            {
                return findNode(p.LeftSon, value);
            }
            else
            {
                return findNode(p.RightSon, value);
            }
        }

        static public Node insertNode(Node p, int value)
        {
            if (p == null)
            {
                return new Node(value);
            }
            if (rand.Next() % (p.Size + 1) == 0)
            {
                return insertRoot(p, value);
            }
            if (p.Value > value)
            {
                p.LeftSon = insertNode(p.LeftSon, value);
            }
            else
            {
                p.RightSon = insertNode(p.RightSon, value);
            }
            return p;
        }

        static public Node insertRoot(Node p, int value)
        {
            if (p == null) return new Node(value);
            if (value < p.Value)
            {
                p.LeftSon = insertRoot(p.LeftSon, value);
                return rotateRight(p);
            }
            else
            {
                p.RightSon = insertRoot(p.RightSon, value);
                return rotateLeft(p);
            }
        }


        static public int getSize(Node p)
        {
            if (p == null) return 0;
            else
                return p.Size;
        }


        static public void fixSize(Node p)
        {
            p.Size = getSize(p.LeftSon) + getSize(p.RightSon) + 1;
        }

        static public Node rotateRight(Node p)
        {
            Node q = p.LeftSon;
            if (q == null)
            {
                return p;
            }
            p.LeftSon = q.RightSon;
            q.RightSon = p;
            q.Size = p.Size;
            fixSize(p);
            return q;
        }
        static public Node rotateLeft(Node q)
        {
            Node p = q.RightSon;
            if (p == null)
            {
                return q;
            }
            q.RightSon = p.LeftSon;
            p.LeftSon = q;
            p.Size = q.Size;
            fixSize(q);
            return p;
        }

        static public int printTree(Node p, int prefix_number = 0, bool isRoot = false)
        {
            int max_deep = prefix_number;

            if (p.LeftSon != null)
            {
                int left_deep = printTree(p.LeftSon, prefix_number + 1);
                if (max_deep < left_deep)
                    max_deep = left_deep;
            }

            string output = $"NODE HASH({p.GetHashCode()}) VALUE({p.Value})";
            if (isRoot)
                output = "ROOT " + output;

            int prefix_counter = 0;
            while (prefix_counter < prefix_number)
            {
                output = "+" + output;
                prefix_counter++;
            }
            output = $"{prefix_number}" + output;

            Console.WriteLine(output);

            if (p.RightSon != null)
            {
                int right_deep = printTree(p.RightSon, prefix_number + 1);
                if (max_deep < right_deep)
                    max_deep = right_deep;
            }
            return max_deep;
        }
    }

    class Node
    {
        int value;
        int size;
        Node leftSon;
        Node rightSon;

        public int Value { get => value; set => this.value = value; }
        public int Size { get => size; set => this.size = value; }
        public Node LeftSon { get => leftSon; set => this.leftSon = value; }
        public Node RightSon { get => rightSon; set => this.rightSon = value; }

        public Node(int value)
        {
            Value = value;
            size = 1;
            LeftSon = null;
            RightSon = null;
        }
    }
}