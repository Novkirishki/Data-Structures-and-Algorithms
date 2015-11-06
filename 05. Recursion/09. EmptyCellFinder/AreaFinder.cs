namespace _09.EmptyCellFinder
{
    using Common;
    using System.Collections.Generic;

    public class AreaFinder
    {
        public List<Position> FindLargestArea(string[,] matrix)
        {
            var maxArea = new List<Position>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        var area = FindArea(new Position(i, j), matrix);
                        FillMatrix(area, matrix);
                        if (area.Count > maxArea.Count)
                        {
                            maxArea = area;
                        }
                    }
                }
            }

            return maxArea;
        }

        protected static List<Position> FindArea(Position start, string[,] matrix, List<Position> area = null)
        {
            if (!IsInRange(start, matrix))
            {
                return new List<Position>();
            }

            if (area == null)
            {
                area = new List<Position>();
                area.Add(start);
                matrix[start.X, start.Y] = "x";
            }

            if (IsInRange(new Position(start.X + 1, start.Y), matrix) && matrix[start.X + 1, start.Y] == "0")
            {
                matrix[start.X + 1, start.Y] = "x";
                area.Add(new Position(start.X + 1, start.Y));
                FindArea(new Position(start.X + 1, start.Y), matrix, area);
            }

            if (IsInRange(new Position(start.X, start.Y + 1), matrix) && matrix[start.X, start.Y + 1] == "0")
            {
                matrix[start.X, start.Y + 1] = "x";
                area.Add(new Position(start.X, start.Y + 1));
                FindArea(new Position(start.X, start.Y + 1),matrix, area);
            }

            if (IsInRange(new Position(start.X - 1, start.Y), matrix) && matrix[start.X - 1, start.Y] == "0")
            {
                matrix[start.X - 1, start.Y] = "x";
                area.Add(new Position(start.X - 1, start.Y));
                FindArea(new Position(start.X - 1, start.Y), matrix, area);
            }

            if (IsInRange(new Position(start.X, start.Y - 1), matrix) && matrix[start.X, start.Y - 1] == "0")
            {
                matrix[start.X, start.Y - 1] = "x";
                area.Add(new Position(start.X, start.Y - 1));
                FindArea(new Position(start.X, start.Y - 1), matrix, area);
            }

            return area;
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

        private static void FillMatrix(List<Position> area, string[,] matrix)
        {
            foreach (var position in area)
            {
                matrix[position.X, position.Y] = "x";
            }
        }
    }
}
