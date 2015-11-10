//We are given a matrix of passable and non-passable cells.
//Write a recursive program for finding all paths between two cells in the matrix.

namespace _07.Pathfinder
{

    using Common;

    public class Startup
    {
        public static void Main()
        {
            string[,] matrix = new string[6, 6]
                {
                    { "0", "0", "0", "x", "0", "x"},
                    { "0", "x", "0", "x", "0", "x"},
                    { "0", "0", "x", "0", "x", "0"},
                    { "0", "x", "0", "0", "0", "0"},
                    { "0", "0", "0", "x", "x", "0"},
                    { "0", "0", "0", "x", "0", "x"},
                };

            var start = new Position(2, 1);
            var end = new Position(2, 3);

            Pathfinder.Find(start, end, matrix);
        }
    }
}
