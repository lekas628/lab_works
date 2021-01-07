using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            //task();
        }

        static void task()
        {
            Graph graph = new Graph();

            string[] NodeNames = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            (string from, string to, int cost)[] Ways = new(string, string, int)[] { 
                ("a", "b", 10), ("a", "d", 19),
                ("b", "c", 2),
                ("c", "a", 8), ("c", "e", 3),
                ("d", "b", 10), ("d", "c", 2), ("d", "e", 6), ("d", "f", 20), ("d", "g", 20),
                ("e", "a", 3),
                ("f", "h", 4), ("f", "g", 4),
                // g -
                // h -
            };
            
            
            graph.NodeAdd(NodeNames);
            graph.WayAdd(Ways);



            graph.PrintInfo();
        }


        static void run()
        {
            Graph graph1 = new Graph();
            graph1.NodeAdd("0");
            graph1.NodeAdd("1");
            graph1.NodeAdd("2");
            graph1.NodeAdd("3");
            graph1.NodeAdd("4");
            graph1.NodeAdd("5");
            graph1.NodeAdd("6");
            graph1.NodeAdd("7");
            graph1.NodeAdd("8");


            graph1.WayAdd("0", "1", 1);
            graph1.WayAdd("0", "3", 1);
            graph1.WayAdd("0", "4", 1);
            graph1.WayAdd("1", "2", 1);
            graph1.WayAdd("1", "3", 1);
            graph1.WayAdd("2", "3", 1);
            graph1.WayAdd("3", "5", 1);
            graph1.WayAdd("4", "6", 1);
            graph1.WayAdd("4", "7", 1);
            graph1.WayAdd("6", "7", 1);
            graph1.WayAdd("7", "8", 1);

            Console.WriteLine("PRINT FIRST GRAPH INFO");
            graph1.PrintInfo();

            Graph graph2 = new Graph();
            graph2.NodeAdd("a");
            graph2.NodeAdd("b");
            graph2.NodeAdd("c");
            graph2.NodeAdd("d");
            graph2.NodeAdd("e");

            graph2.WayAdd("a", "b", 1);
            graph2.WayAdd("a", "d", 1);
            graph2.WayAdd("b", "e", 1);
            graph2.WayAdd("c", "a", 1);
            graph2.WayAdd("c", "e", 1);
            graph2.WayAdd("d", "b", 1);
            graph2.WayAdd("d", "c", 1);
            graph2.WayAdd("d", "e", 1);
            graph2.WayAdd("e", "a", 1);

            Console.WriteLine("PRINT SECOND GRAPH INFO");
            graph2.PrintInfo();
        }

 
    }
}
