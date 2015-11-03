namespace _1.TreeParser
{
    using System;
    using System.Linq;

    public static class TreeReader
    {
        public static Tree Read()
        {
            var size = int.Parse(Console.ReadLine());

            var tree = new Tree();

            var line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                var parentChildPair = line.Split(new char[] { ' ' });
                var parentValue = int.Parse(parentChildPair[0]);
                var childValue = int.Parse(parentChildPair[1]);

                var parentNode = new TreeNode(parentValue);
                var childNode = new TreeNode(childValue);

                foreach (var node in tree.Nodes)
                {
                    if (node.Value == parentValue)
                    {
                        parentNode = node;
                    }

                    if (node.Value == childValue)
                    {
                        childNode = node;
                    }
                }

                tree.Nodes.Add(childNode);
                tree.Nodes.Add(parentNode);

                childNode.Parent = parentNode;
                parentNode.Children.Add(childNode);

                line = Console.ReadLine();
            }

            return tree;
        }
    }
}
