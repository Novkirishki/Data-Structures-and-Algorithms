namespace _3.FileTree
{
    using System.Collections.Generic;

    public class Tree
    {
        public Tree(string rootPath)
        {
            this.Root = new Folder(rootPath);
        }

        public Folder Root { get; private set; }

        public int CalculateSubtreeSize(Folder folder, int size = 0)
        {
            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var subfolder in folder.ChildFolders)
            {
                size += CalculateSubtreeSize(subfolder);
            }

            return size;
        }
    }
}
