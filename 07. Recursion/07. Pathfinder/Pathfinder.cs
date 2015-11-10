namespace _07.Pathfinder
{
    using Common;
    using System;
    using System.Text;

    public class Pathfinder
    {
        public static void Find(Position start, Position end, string[,] matrix, Position[] path = null, int counter = 0)
        {
            if (!IsInRange(start, matrix))
            {
                return;
            }

            if (!IsInRange(end, matrix))
            {
                return;
            }

            if (start == end)
            {
                PrintPath(path, counter);
                return;
            }

            if (path == null)
            {
                path = new Position[matrix.GetLength(0) * matrix.GetLength(1)];
                path[counter] = start;
                ++counter;
            }

            if (IsInRange(new Position(start.X + 1, start.Y), matrix) && matrix[start.X + 1, start.Y] == "0")
            {
                matrix[start.X + 1, start.Y] = "x";
                path[counter] = new Position(start.X + 1, start.Y);
                Find(new Position(start.X + 1, start.Y), end, matrix, path, counter + 1);
                matrix[start.X + 1, start.Y] = "0";
            }

            if (IsInRange(new Position(start.X, start.Y + 1), matrix) && matrix[start.X, start.Y + 1] == "0")
            {
                matrix[start.X, start.Y + 1] = "x";
                path[counter] = new Position(start.X, start.Y + 1);
                Find(new Position(start.X, start.Y + 1), end, matrix, path, counter + 1);
                matrix[start.X, start.Y + 1] = "0";
            }

            if (IsInRange(new Position(start.X - 1, start.Y), matrix) && matrix[start.X - 1, start.Y] == "0")
            {
                matrix[start.X - 1, start.Y] = "x";
                path[counter] = new Position(start.X - 1, start.Y);
                Find(new Position(start.X - 1, start.Y), end, matrix, path, counter + 1);
                matrix[start.X - 1, start.Y] = "0";
            }

            if (IsInRange(new Position(start.X, start.Y - 1), matrix) && matrix[start.X, start.Y - 1] == "0")
            {
                matrix[start.X, start.Y - 1] = "x";
                path[counter] = new Position(start.X, start.Y - 1);
                Find(new Position(start.X, start.Y - 1), end, matrix, path, counter + 1);
                matrix[start.X, start.Y - 1] = "0";
            }
        }

        private static bool IsInRange(Position start, string[,] matrix)
        {
            if (start.X >= matrix.GetLength(0) || start.X < 0)
            {
                return false;
            }

            if (start.Y >= matrix.GetLength(1) || start.Y < 0)
            {
                return false;
            }

            return true;
        }

        private static void PrintPath(Position[] path, int counter)
        {
            var builder = new StringBuilder();
            builder.Append("{");

            for (int i = 0; i < counter; i++)
            {
                builder.Append(path[i].ToString() + ", ");
            }

            builder.Append("}");

            Console.WriteLine(builder);        
        }
    }
}
