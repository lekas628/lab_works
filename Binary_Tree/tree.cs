using System;

namespace Tree
{
    class Binary_Tree
    {
        private Node root;
        public Node Root { get => root; private set => root = value; }


        public Binary_Tree(int value)
        {
            Root = new Node(value);
        }

        public int getRootValue()
        {
            return Root.Value;
        }

        public void addNode(int value)
        {
            bool isSet = false;
            Node newNode = new Node(value);
            Node currentCompareNode = root;
            while(!isSet)
            {
                if(value <= currentCompareNode.Value)
                {
                    if(currentCompareNode.LeftSon == null)
                    {
                        currentCompareNode.LeftSon = newNode;
                        isSet = true;
                    }
                    else
                    {
                        currentCompareNode = currentCompareNode.LeftSon;
                    }
                }
                else
                {
                    if(currentCompareNode.RightSon == null)
                    {
                        currentCompareNode.RightSon = newNode;
                        isSet = true;
                    }
                    else
                    {
                        currentCompareNode = currentCompareNode.RightSon;
                    }
                }

            }
        }

        public bool isElementInTree(int value)
        {
            Node currentCompareNode = Root;
            while(currentCompareNode != null)
            {
                if(value < currentCompareNode.Value)
                {
                    currentCompareNode = currentCompareNode.LeftSon;
                }
                else if (value > currentCompareNode.Value)
                {
                    currentCompareNode = currentCompareNode.RightSon;
                }
                else
                {
                    return true;
                }
            }
            return false; 
        }
    }

    class Node
    {
        int value;
        Node leftSon;
        Node rightSon;

        public int Value { get => value; set => this.value = value; }
        public Node LeftSon { get => leftSon; set => this.leftSon = value; }
        public Node RightSon{ get => rightSon; set => this.rightSon = value; }

        public Node(int value)
        {
            Value = value;
            LeftSon = null;
            RightSon = null; 
        }
    }
}