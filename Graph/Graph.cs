using System;
using System.Collections.Generic;
using System.Text;
  


namespace Graph
{
    class Graph
    {
        public int[][] B;
        public string[] Names;


        public int[] colors;
        public int[] parent;
        public int[] distanceToFirstNode;
        Queue<int> queue;
        public int[] maxDistancePath;

        public Graph(int nodeNumber = 0)
        {
            B = new int[0][];
            Names = new string[0];
        }
        public void NodeAdd(string Name)
        {
            int oldNodeLenght = B.Length;

            int[][] newB = new int[oldNodeLenght + 1][];
            for (int i = 0; i < newB.Length; i++)
                newB[i] = new int[(oldNodeLenght + 1) * (oldNodeLenght + 1)];

            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    for(int k = 0; k < B.Length; k++)
                    {
                        newB[i][k + j * oldNodeLenght + j] = B[i][k + j * oldNodeLenght];
                    }
                }
            }
            NameAdd(Name);
            B = newB;
        }

        public void NodeAdd(string[] Names)
        {
            foreach (string name in Names)
                NodeAdd(name);
        }


        public int NodeDel(string Name)
        {
            int ID = NodeGetID(Name);
            if (ID == -1)
                return -1;
            NameDel(Name);

            if (B.Length == 0)
            {
                Console.WriteLine("Graph is empty");
                return -1;
            }

            int oldNodeLenght = B.Length;
            int[][] newB = new int[oldNodeLenght - 1][];
            for (int i = 0; i < newB.Length; i++)
                newB[i] = new int[(oldNodeLenght - 1) * (oldNodeLenght - 1)];

            int Ioffset = 0;
            int Joffset = 0;
            int Koffset = 0;

            for (int i = 0; i < B.Length; i++)
            {
                if (i == ID)
                {
                    Ioffset = 1;
                    continue;
                }

                for (int j = 0; j < B.Length; j++)
                {
                    if (j == ID)
                    {
                        Joffset = 1;
                        continue;
                    }

                    for (int k = 0; k < B.Length; k++)
                    {
                        if (k == ID)
                        {
                            Koffset = 1;
                            continue;
                        }

                        newB[i + Ioffset][(k + Koffset) + (j + Joffset) * oldNodeLenght + (j + Joffset)] =
                            B[i][k + j * oldNodeLenght];
                    }
                    Koffset = 0;
                }
                Joffset = 0;
            }

            B = newB;
            return 0;
        }

        public int NodeGetID(string Name)
        {
            for (int i = 0; i < Names.Length; i++)
                if (Names[i] == Name.ToLower())
                    return i;
            Console.WriteLine($"cant find {Name}");
            return -1;
        }
        public bool NodeExist(string Name)
        {
            int ID = NodeGetID(Name);
            if (ID == -1)
                return false;
            else return NodeExistByID(ID);
        }

        public bool NodeExistByID(int NodeID)
        {
            if (NodeID < 0 || NodeID >= B.Length)
            {
                Console.WriteLine("One of the node does not exist");
                return false;
            }
            return true;
        }


        public void NameAdd(string Name)
        {
            string[] newNames = new string[Names.Length + 1];
            for(int i = 0; i < Names.Length; i++)
            {
                newNames[i] = Names[i];
            }
            newNames[Names.Length] = Name.ToLower();
            Names = newNames;
        }

        public int NameDel(string Name)
        {
            if(Names.Length == 0)
            {
                Console.WriteLine("Graph is empty");
                return -1;
            }

            string[] newNames = new string[Names.Length - 1];
            int offset = 0;
            for(int i = 0; i < Names.Length; i++)
            {
                if (Names[i] == Name)
                {
                    offset = 1;
                    continue;
                }
                newNames[i - offset] = Names[i];
            }
            Names = newNames;
            return 0;
        }

        public int NameChange(string oldName, string newName)
        {
            if (Names.Length == 0)
            {
                Console.WriteLine("Graph is empty");
                return -1;
            }

            for(int i = 0; i < Names.Length; i++)
            {
                if(Names[i] == oldName.ToLower())
                {
                    Names[i] = newName.ToLower();
                }
            }
            return 0;
        }

        public int WayAdd(string fromNode, string toNode, int cost)
        {
            int from = NodeGetID(fromNode);
            int to = NodeGetID(toNode);
            if (from == -1 || to == -1)
                return -1;
            return WayAddByID(from, to, cost);
        }

        public void WayAdd((string, string, int)[] wayArray)
        {
            foreach((string from, string to, int cost) way in wayArray)
            {
                WayAdd(way.from, way.to, way.cost);
            }
        }




        public int WayDel(string fromNode, string toNode)
        {
            int from = NodeGetID(fromNode);
            int to = NodeGetID(toNode);
            if (from == -1 || to == -1)
                return -1;
            return WayDelByID(from, to);
        }

        public int WayEdit(string fromNode, string toNode, int cost)
        {
            int from = NodeGetID(fromNode);
            int to = NodeGetID(toNode);
            if (from == -1 || to == -1)
                return -1;
            return WayEditByID(from, to, cost);
        }

        public int WayGet(string fromNode, string toNode)
        {
            int from = NodeGetID(fromNode);
            int to = NodeGetID(toNode);
            if (from == -1 || to == -1)
                return -1;
            return WayGetByID(from, to);
        }

        //// if Max = true return max neighbor way cost, else return min way cost
        //// return (int, int) first is Node ID, second is cost
        //public (int, int) WayGet(string fromNode, bool Max)
        //{
        //    int ID = NodeGetID(fromNode);
        //    if (ID == -1)
        //        return (-1, -1);
        //    return WayGetByID(ID, Max);

        //}

        public int WayAddByID(int fromNode, int toNode, int cost)
        {
            if (!NodeExistByID(fromNode) || !NodeExistByID(toNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }

            if(B[fromNode][fromNode * B.Length + toNode] != 0)
            {
                Console.WriteLine($"Road {fromNode} {toNode} already exist");
                return -1;
            }
            B[fromNode][fromNode * B.Length + toNode] = cost;
            B[toNode][toNode * B.Length + fromNode] = -cost;
            return 0;
        }

        public int WayDelByID(int fromNode, int toNode)
        {
            if (!NodeExistByID(fromNode) || !NodeExistByID(toNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }

            if (B[fromNode][fromNode * B.Length + toNode] == 0)
            {
                Console.WriteLine("Road does not exist");
                return -1;
            }
            B[fromNode][fromNode * B.Length + toNode] = 0;
            B[toNode][toNode * B.Length + fromNode] = 0;
            return 0;
        }

        public int WayEditByID(int fromNode, int toNode, int cost)
        {
            if (!NodeExistByID(fromNode) || !NodeExistByID(toNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }

            if (B[fromNode][fromNode * B.Length + toNode] == 0)
            {
                Console.WriteLine("Road does not exist");
                return -1;
            }
            B[fromNode][fromNode * B.Length + toNode] = cost;
            B[toNode][toNode * B.Length + fromNode] = -cost;
            return 0;
        }
        public int WayGetByID(int fromNode, int toNode)
        {
            if (!NodeExistByID(fromNode) || !NodeExistByID(toNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }
            return B[fromNode][fromNode * B.Length + toNode];
        }
        
        //public (int, int) WayGetByID(int fromNode, bool Max)
        //{
        //    if (!NodeExistByID(fromNode))
        //    {
        //        Console.WriteLine("One of the node does not exist");
        //        return (-1, -1);
        //    }

        //    int resultID;
        //    int resultCost;

        //    if(fromNode == 0)
        //    {
        //        resultCost = B[0][1];
        //        resultID = 1;
        //    }
        //    else
        //    {
        //        resultCost = B[fromNode][fromNode * B.Length];
        //        resultID = 0;
        //    }


        //    int currentCost;
        //    for(int i = 0; i < B.Length; i++)
        //    {
        //        if (i == fromNode)
        //            continue;

        //        currentCost = B[fromNode][fromNode * B.Length + i];
        //        if (Max == true)
        //        {
        //            if(currentCost > resultCost)
        //            {
        //                resultID = i;
        //                resultCost = currentCost;
        //            }
        //        }
        //        else
        //        {
        //            if (currentCost < resultCost && currentCost > 0)
        //            {
        //                resultID = i;
        //                resultCost = currentCost;
        //            }
        //        }
        //    }

        //    return (resultID, resultCost);
        //}

        public int WayGetNextNodeByID(int fromNode)
        {
            if(!NodeExistByID(fromNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }

            int cost = 0;
            for(int i = 0; i < B.Length; i++)
            {
                if (i == fromNode)
                    continue;
                int current = B[fromNode][fromNode * B.Length + i];
                if(current > cost)
                {
                    return i;
                }
            }
            return -1;
        }

        public int WayGetNextNodeByID(int fromNode, int afterNode)
        {
            if (!NodeExistByID(fromNode) || !NodeExistByID(afterNode))
            {
                Console.WriteLine("One of the node does not exist");
                return -1;
            }

            int cost = 0;
            for (int i = afterNode; i < B.Length; i++)
            {
                if (i == fromNode)
                    continue;
                int current = B[fromNode][fromNode * B.Length + i];
                if (current > cost)
                {
                    return i;
                }
            }
            return -1;
        }

        public void BFS(int StartNodeID)
        {
            colors = new int[B.Length];
            parent = new int[B.Length];
            distanceToFirstNode = new int[B.Length];
            queue = new Queue<int>();

            for(int i = 0; i < B.Length; i++)
            {
                colors[i] = 0;
                parent[i] = 0;
                distanceToFirstNode[i] = -1;
            }
            colors[0] = 1;
            queue.Clear();


            distanceToFirstNode[StartNodeID] = 0;
            parent[StartNodeID] = 0;

            queue.Enqueue(StartNodeID);

            int currentNodeID;

            while(queue.Count != 0)
            {
                currentNodeID = queue.Dequeue();
                // добавить потом защиту от петель если нужно
                for(int i = 0; i < B.Length; i++)
                {
                    if(B[currentNodeID][currentNodeID * B.Length + i] > 0)
                    {
                        if(colors[i] == 0)
                        {
                            colors[i] = 1;
                            parent[i] = currentNodeID;
                            distanceToFirstNode[i] = distanceToFirstNode[currentNodeID] + 1;
                            queue.Enqueue(i);
                        }
                    }
                }
                colors[currentNodeID] = 2;
            }
        }

        public void PrintMaxtrixInformation()
        {
            for(int i = 0; i < B.Length; i++)
            {
                string lineOutput = "";
                lineOutput += $"{Names[i].ToUpper(), 6}\t";
                foreach(int number in B[i])
                {
                    lineOutput += $"{number, 3}";
                }

                Console.WriteLine(lineOutput);
            }
        }

        public int GetMaxRadius()
        {
            int maxRadius = 0;
            for(int i = 0; i < B.Length; i++)
            {
                BFS(i);
                for(int j = 0; j < B.Length; j++)
                {
                    if(maxRadius < distanceToFirstNode[j])
                    {
                        maxRadius = distanceToFirstNode[j];
                        UpdatePath(j);
                    }
                }
            }
            return maxRadius;
        }

        public void UpdatePath(int NodeDestinationID)
        {
            maxDistancePath = new int[distanceToFirstNode[NodeDestinationID] + 1];
            for (int i = 0; i < maxDistancePath.Length; i++)
                maxDistancePath[i] = 0;

            int d = distanceToFirstNode[NodeDestinationID];
            if(d != -1)
            {
                maxDistancePath[d] = NodeDestinationID;
                while(d != 0)
                {
                    maxDistancePath[d - 1] = parent[NodeDestinationID];
                    NodeDestinationID = parent[NodeDestinationID];
                    d = distanceToFirstNode[NodeDestinationID];
                }
            }
        }

        public void PrintlastPathInformation()
        {
            if (maxDistancePath != null)
            {
                Console.WriteLine("\nPath");
                foreach (int nodeID in maxDistancePath)
                {
                    Console.Write($"{Names[nodeID],5}");
                }
                Console.WriteLine("\n");
            }
        }

        public void PrintlastPathInformationUsingID()
        {
            if (maxDistancePath != null)
            {
                Console.WriteLine("\nPath");
                foreach (int nodeID in maxDistancePath)
                {
                    Console.Write($"{nodeID,5}");
                }
                Console.WriteLine("\n");
            }
        }

        public void PrintLastBFSInformation()
        {
            if (distanceToFirstNode != null)
            {
                Console.WriteLine("\nColors");
                string lineOutput = "";
                foreach (int number in colors)
                {
                    lineOutput += $"{number,5}";
                }

                Console.WriteLine(lineOutput);

                Console.WriteLine("\nParents");
                lineOutput = "";
                foreach (int number in parent)
                {
                    lineOutput += $"{number,5}";
                }

                Console.WriteLine(lineOutput);

                Console.WriteLine("\ndistanceToFirstNode");
                lineOutput = "";
                foreach (int number in distanceToFirstNode)
                {
                    lineOutput += $"{number,5}";
                }

                Console.WriteLine(lineOutput);
            }
        }

        public void PrintInfo()
        {
            PrintMaxtrixInformation();
            int maxRadius = GetMaxRadius();
            Console.WriteLine($"Max radius is {maxRadius}");
            PrintlastPathInformation();
        }
    }
}
