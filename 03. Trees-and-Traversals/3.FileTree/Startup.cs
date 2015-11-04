// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
// Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.
// Use recursive DFS traversal.

namespace _3.FileTree
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            // The program most probably will throw an error with this folder because you dont have access rights.
            // Better give some other folder for root and see the results :)
            // For example: @"C:\Program Files\WinRAR"
            var SourceDirectory = @"C:\Program Files\WinRAR";

            var tree = new Tree(SourceDirectory);

            var subtreeRootFolder = tree.Root;

            double sizeInMB = (double)tree.CalculateSubtreeSize(subtreeRootFolder) / 1000000;
            Console.WriteLine("The size of the files from the subtree with root {0} is {1} MB", subtreeRootFolder.Name, sizeInMB);
        }
    }
}
