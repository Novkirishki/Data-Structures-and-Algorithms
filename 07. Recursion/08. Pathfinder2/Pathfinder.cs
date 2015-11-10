namespace _08.Pathfinder2
{
    using Common;
    using System;

    public class Pathfinder
    {
        public static bool Find(Position start, Position end, string[,] matrix)
        {
            if (!IsInRange(start, matrix))
            {
                return false;
            }

            if (!IsInRange(end, matrix))
            {
                return false;
            }

            if (start == end)
            {
                Console.WriteLine("A path is found");      
                return true;
            }

            if (IsInRange(new Position(start.X + 1, start.Y), matrix) && matrix[start.X + 1, start.Y] == "0")
            {
                matrix[start.X + 1, start.Y] = "x";
                if (Find(new Position(start.X + 1, start.Y), end, matrix))
                {
                    return true;
                }               
            }

            if (IsInRange(new Position(start.X, start.Y + 1), matrix) && matrix[start.X, start.Y + 1] == "0")
            {
                matrix[start.X, start.Y + 1] = "x";
                if (Find(new Position(start.X, start.Y + 1), end, matrix))
                {
                    return true;
                }               
            }

            if (IsInRange(new Position(start.X - 1, start.Y), matrix) && matrix[start.X - 1, start.Y] == "0")
            {
                matrix[start.X - 1, start.Y] = "x";
                if (Find(new Position(start.X - 1, start.Y), end, matrix))
                {
                    return true;
                }
            }

            if (IsInRange(new Position(start.X, start.Y - 1), matrix) && matrix[start.X, start.Y - 1] == "0")
            {
                matrix[start.X, start.Y - 1] = "x";
                if (Find(new Position(start.X, start.Y - 1), end, matrix))
                {
                    return true;
                }
            }

            return false;
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
    }
}
