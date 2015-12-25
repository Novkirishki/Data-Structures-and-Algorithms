// THANKS TO http://stackoverflow.com/questions/20864641/finding-minimum-completion-time-of-scheduled-tasks-with-topological-sort

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Graph
    {
        public List<Node> Nodes
        {
            get; set;
        }

        public Graph()
        {
            this.Nodes = new List<Node>();
        }
    }

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Parents = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Parents { get; set; }
    }

    class Program
    {
        private static List<Node> TopologicalSort(Graph graph)
        {
            var sortedElements = new List<Node>();
            var elementsWithNoIncomingEdges = graph.Nodes.Where(n => n.Parents.Count == 0).ToList();

            while (elementsWithNoIncomingEdges.Count > 0)
            {
                var nodeN = elementsWithNoIncomingEdges[0];
                sortedElements.Add(nodeN);
                elementsWithNoIncomingEdges.Remove(nodeN);

                var ChildrenOfNodeN = graph.Nodes.Where(n => n.Parents.Contains(nodeN)).ToList();
                foreach (var nodeM in ChildrenOfNodeN)
                {
                    nodeM.Parents.Remove(nodeN);
                    if (nodeM.Parents.Count == 0)
                    {
                        elementsWithNoIncomingEdges.Add(nodeM);

                    }
                }
            }
            if (graph.Nodes.Where(n => (n.Parents.Count > 0)).ToList().Count > 0)
            {
                return new List<Node>();
            }
            else
            {
                return sortedElements;
            }
        }

        static void Main(string[] args)
        {
            var graph1 = new Graph();
            var graph = new Graph();
            var n = int.Parse(Console.ReadLine());
            var nodeValues = Console.ReadLine().Split(' ').Select(int.Parse);
            foreach (var value in nodeValues)
            {
                var node = new Node(value);
                graph.Nodes.Add(node);
                var node1 = new Node(value);
                graph1.Nodes.Add(node1);
            }

            for (int i = 0; i < n; i++)
            {
                var parents = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (parents[0] == 0)
                {
                    continue;
                }
                else
                {
                    foreach (var parent in parents)
                    {
                        graph.Nodes[i].Parents.Add(graph.Nodes[parent - 1]);
                        graph1.Nodes[i].Parents.Add(graph1.Nodes[parent - 1]);
                    }
                }
            }

            var topologicalOrder = TopologicalSort(graph1);
            if (topologicalOrder.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(MinTime(graph, topologicalOrder));
        }

        private static long MinTime(Graph graph, List<Node> order)
        {
            var distance = new long[order.Count];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = -1;
            }

            long maxDist = 0;
            for (int i = 0; i < order.Count; i++)
            {
                if (distance[i] == -1)
                {
                    maxDist = Math.Max(maxDist, LongestPath(graph, distance, i));
                }
            }

            return maxDist;
        }

        private static long LongestPath(Graph graph, long[] distance, int i)
        {
            long maxDist = 0;
            var nodeI = graph.Nodes[i];
            var childrenOfNodeI = graph.Nodes.Where(n => n.Parents.Contains(nodeI)).ToList();
            foreach (var node in childrenOfNodeI)
            {
                var indexOfCurrentNodeW = graph.Nodes.IndexOf(node);
                if (distance[indexOfCurrentNodeW] == -1)
                {
                    LongestPath(graph, distance, indexOfCurrentNodeW);
                }
                maxDist = Math.Max(maxDist, distance[indexOfCurrentNodeW]);
            }
            distance[i] = maxDist + graph.Nodes[i].Value;
            return distance[i];
        }
    }
}
