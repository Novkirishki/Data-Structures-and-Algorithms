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
            var SourceDirectory = @"C:\Windows";
            var regex = new Regex(@"^*.exe$");

            var directoriesPaths = new Queue<string>();

            directoriesPaths.Enqueue(SourceDirectory);

            while (directoriesPaths.Count != 0)
            {
                var currentDirectory = directoriesPaths.Dequeue();
                try
                {
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
