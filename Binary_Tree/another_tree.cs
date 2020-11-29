using System;

namespace Another_Tree
{
    partial class AnotherTree
    {
        private Node root;
        public Node Root { get => root; private set => root = value; }
        static private Random rand = new Random();


        public AnotherTree(int value)
        {
            Root = new Node(value);
        }

        static public Node findNode(Node p, int value)
        {
            if( p == null ) 
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
            if ( p == null)
            {
                return new Node(value);
            }
            if ( rand.Next()%(p.Size + 1) == 0)
            {
                return insertRoot(p, value);
            }
            if( p.Value > value)
            {
                p.LeftSon = insertNode(p.LeftSon, value);
            }
            else
            {
                p.RightSon = insertNode(p.RightSon, value);
            }
            fixSize(p);
            return p;
        }
        static public int getSize(Node p)
        {
            if ( p == null)
            {
                return 0;
            }
            return p.Size;
        }
        static public void fixSize(Node p)
        {
            p.Size = getSize(p.LeftSon) + getSize(p.RightSon) + 1;
        }

        static Node rotateRight(Node p)
        {
            Node q = p.LeftSon;
            if ( q == null) 
            {
                return p;
            }
            p.LeftSon = q.RightSon;
            q.RightSon = p;
            q.Size = p.Size;
            fixSize(p);
            return q;
        }
        static Node rotateLeft(Node q)
        {
            Node p = q.RightSon;
            if(p == null)
            {
                return q;
            }
            q.RightSon = p.LeftSon;
            p.LeftSon = q;
            p.Size = q.Size;
            fixSize(q);
            return p;
        }
        static Node insertRoot(Node p, int value)
        {
            if(p == null)
            {
                return new Node(value);
            }
            if( value < p.Value)
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
        public Node RightSon{ get => rightSon; set => this.rightSon = value; }

        public Node(int value)
        {
            Value = value;
            size = 1;
            LeftSon = null;
            RightSon = null; 
        }
    }
}