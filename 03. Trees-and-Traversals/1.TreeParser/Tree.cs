namespace _1.TreeParser
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tree
    {
        private ICollection<TreeNode> nodes;

        public Tree()
        {
            this.Nodes = new HashSet<TreeNode>();
        }

        public ICollection<TreeNode> Nodes
        {
            get
            {
                return nodes;
            }

            private set
            {
                nodes = value;
            }
        }

        public TreeNode GetRoot()
        {
            return this.Nodes.Where(n => n.Parent == null).FirstOrDefault();
        }

        public ICollection<TreeNode> GetLeafs()
        {
            return this.Nodes.Where(n => n.Children.Count == 0).ToList();
        }

        public ICollection<TreeNode> GetMiddleNodes()
        {
            return this.Nodes.Where(n => n.Children.Count != 0 && n.Parent != null).ToList();
        }

        public Path GetLongestPath()
        {
            var counter = 0;
            var maxCounter = 0;
            var leafs = this.GetLeafs();
            TreeNode leafOfLongestPath = null;

            foreach (var leaf in leafs)
            {
                var node = leaf;

                while (node.Parent != null)
                {
                    ++counter;
                    node = node.Parent;
                }

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    leafOfLongestPath = leaf;
                }

                counter = 0;
            }

            return new Path(this.GetRoot(), leafOfLongestPath);
        }

        public ICollection<Path> GetPathsWithSum(int targetSum)
        {
            var paths = new HashSet<Path>();

            foreach (var node in this.Nodes)
            {
                var currentNode = node;
                var sum = 0;

                while (currentNode != null)
                {
                    sum += currentNode.Value;

                    if (sum == targetSum)
                    {
                        paths.Add(new Path(currentNode, node));
                    }

                    if (sum > targetSum)
                    {
                        sum = 0;
                        break;
                    }

                    currentNode = currentNode.Parent;
                }
            }

            return paths;
        }

        public ICollection<TreeNode> GetSubtreesWithGivenSumRoot(int targetSum)
        {
            var roots = new HashSet<TreeNode>();

            foreach (var node in this.Nodes)
            {
                if (node.GetSum() == targetSum)
                {
                    roots.Add(node);
                }
            }

            return roots;
        }
    }
}
