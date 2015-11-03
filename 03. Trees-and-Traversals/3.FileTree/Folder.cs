namespace _3.FileTree
{
    public class Folder
    {
        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }
    }
}
