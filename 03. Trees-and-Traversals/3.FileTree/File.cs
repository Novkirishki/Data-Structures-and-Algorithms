namespace _3.FileTree
{
    using System.IO;

    public class File
    {
        public File(string name)
        {
            this.Name = name;
            this.Size = (int)(new FileInfo(name)).Length;
        }

        public string Name { get; set; }

        public int Size { get; set; }
    }
}
