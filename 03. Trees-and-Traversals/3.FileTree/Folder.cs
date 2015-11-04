namespace _3.FileTree
{
    using System.IO;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            var fileNames = Directory.GetFiles(name);

            this.Files = new File[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                this.Files[i] = new File(fileNames[i]);
            }

            var dirNames = Directory.GetDirectories(name);

            this.ChildFolders = new Folder[dirNames.Length];
            for (int i = 0; i < dirNames.Length; i++)
            {
                this.ChildFolders[i] = new Folder(dirNames[i]);
            }
        }

        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }
    }
}
