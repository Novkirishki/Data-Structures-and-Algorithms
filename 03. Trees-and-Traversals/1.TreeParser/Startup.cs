//You are given a tree of N nodes represented as a set of N-1 pairs of nodes(parent node, child node), each in the range(0..N-1).
//Write a program to read the tree and find:

//the root node
//all leaf nodes
//all middle nodes
//the longest path in the tree
//(*) all paths in the tree with given sum `S` of their nodes
//(*) all subtrees with given sum `S` of their nodes

namespace _1.TreeParser
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var tree = TreeReader.Read();

            // 1.root
            var root = tree.GetRoot();
            Console.WriteLine("The root has value: {0}", root.Value);

            // 2.leafs
            var leadNodes = tree.GetLeafs();
            Console.Write("Leafs are:");
            foreach (var leaf in leadNodes)
            {
                Console.Write(" {0}", leaf.Value);
            }
            Console.WriteLine();

            // 3.middle nodes
            var middleNodes = tree.GetMiddleNodes();
            Console.Write("Middle nodes are:");
            foreach (var node in middleNodes)
            {
                Console.Write(" {0}", node.Value);
            }
            Console.WriteLine();

            // 4.longest path in tree
            var longestPath = tree.GetLongestPath();
            Console.WriteLine("The longest path is from {0} to {1}", longestPath.Start.Value, longestPath.End.Value);

            // 5. paths with given sum
            var sum = 9;
            var paths = tree.GetPathsWithSum(sum);
            Console.WriteLine("Paths with sum {0} are: ", sum);
            foreach (var path in paths)
            {
                Console.WriteLine("Start {0} - end {1}", path.Start.Value, path.End.Value);
            }

            // 6.subtrees with given sum
            var targerSum = 12;
            var rootsOfSubtrees = tree.GetSubtreesWithGivenSumRoot(targerSum);
            Console.Write("Subtrees roots with sum {0}:", targerSum);
            foreach (var rootOfSubtree in rootsOfSubtrees)
            {
                Console.Write(" {0}", rootOfSubtree.Value);
            }
            Console.WriteLine();
        }
    }
}
