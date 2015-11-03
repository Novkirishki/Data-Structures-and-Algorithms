namespace _1.TreeParser
{
    public class Path
    {
        public Path(TreeNode start, TreeNode end)
        {
            this.Start = start;
            this.End = end;
        }

        public TreeNode Start { get; set; }

        public TreeNode End { get; set; }
    }
}
