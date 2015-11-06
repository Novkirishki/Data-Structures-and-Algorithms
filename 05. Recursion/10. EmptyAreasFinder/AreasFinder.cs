namespace _10.EmptyAreasFinder
{
    using Common;
    using System.Collections.Generic;

    public class AreasFinder : _09.EmptyCellFinder.AreaFinder
    {
        public static List<List<Position>> FindAllAreas(string[,] matrix)
        {
            var areas = new List<List<Position>>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        var area = FindArea(new Position(i, j), matrix);
                        areas.Add(area);
                    }
                }
            }

            return areas;
        }
    }
}
