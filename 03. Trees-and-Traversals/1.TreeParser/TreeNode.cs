namespace _1.TreeParser
{
    using System.Collections.Generic;

    public class TreeNode
    {
        private int value;
        private TreeNode parent;
        private ICollection<TreeNode> children;

        public TreeNode(int value)
        {
            this.Value = value;
            parent = null;
            children = new List<TreeNode>();
        }

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public TreeNode Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public ICollection<TreeNode> Children
        {
            get
            {
                return children;
            }

            set
            {
                children = value;
            }
        }

        public int GetSum()
        {
            if (this.Children.Count == 0)
            {
                return this.value;
            }
            else
            {
                var sum = this.Value;
                foreach (var child in this.Children)
                {
                    sum += child.GetSum();
                }

                return sum;
            }
        }
    }
}
