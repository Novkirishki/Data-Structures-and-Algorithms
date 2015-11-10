//Modify the above program to check whether a path exists between two cells without finding all possible paths.
//Test it over an empty 100 x 100 matrix.

namespace _08.Pathfinder2
{
    using Common;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var matrix = new string[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix[i, j] = "0";
                }
            }

            var start = new Position(2, 1);
            var end = new Position(88, 93);

            if (!Pathfinder.Find(start, end, matrix))
            {
                Console.WriteLine("A path is not found");
            }           
        }
    }
}
