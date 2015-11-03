namespace _3.FileTree
{
    using System.IO;
    using System.Linq;

    public class Tree
    {
        public Tree(string rootPath)
        {
            this.Root.Name = rootPath;

            this.Root.Files = Directory.GetFiles(this.Root.Name).Select(f => new File(f)).ToArray();
            

        }

        public Folder Root { get; private set; }
    }
}
