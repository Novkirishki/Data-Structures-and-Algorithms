//Write a program to traverse the directory C:\WINDOWS and all its subdirectories 
//    recursively and to display all files matching the mask *.exe.Use the class System.IO.Directory.

namespace _2.DirectoryTraverse
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            // The program most probably will throw an error with this folder because you dont have access rights.
            // Better give some other folder for root and see the results :)
            // For example: @"C:\Program Files\WinRAR"
            var SourceDirectory = @"C:\Windows";
            var regex = new Regex(@"^*.exe$");

            var directoriesPaths = new Queue<string>();

            directoriesPaths.Enqueue(SourceDirectory);

            while (directoriesPaths.Count != 0)
            {
                var currentDirectory = directoriesPaths.Dequeue();
                var files = Directory.GetFiles(currentDirectory);

                foreach (var file in files)
                {
                    if (regex.IsMatch(file))
                    {
                        Console.WriteLine(file);
                    }
                }

                var directories = Directory.GetDirectories(currentDirectory);

                foreach (var dir in directories)
                {
                    directoriesPaths.Enqueue(dir);
                }
            }
        }
    }
}
