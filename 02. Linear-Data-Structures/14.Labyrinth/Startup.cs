//We are given a labyrinth of size N x N.
//Some of its cells are empty(0) and some are full(x).
//We can move from an empty cell to another empty cell if they share common wall.
//Given a starting position (*) calculate and fill in the array the minimal distance 
//    from this position to any other cell in the array. Use "u" for all unreachable cells.

namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static void FillLabyrinth(string[,] labyrinth)
        {
            Position startingPosition = new Position(-1, -1);

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "*")
                    {
                        startingPosition = new Position(i, j);
                    }
                }
            }

            var queue = new Queue<Position>();
            queue.Enqueue(startingPosition);

            while (queue.Count != 0)
            {
                var position = queue.Dequeue();

                FillCell(labyrinth, position, queue);
            }

            FillUnreachableCells(labyrinth);
        }

        private static void FillCell(string[,] labyrinth, Position position, Queue<Position> queue)
        {
            var value = 1;
            int.TryParse(labyrinth[position.X, position.Y], out value);

            if (IsInRange(new Position(position.X + 1, position.Y), labyrinth) && labyrinth[position.X + 1, position.Y] == "0")
            {
                labyrinth[position.X + 1, position.Y] = (value + 1).ToString();
                queue.Enqueue(new Position(position.X + 1, position.Y));
            }

            if (IsInRange(new Position(position.X, position.Y + 1), labyrinth) && labyrinth[position.X, position.Y + 1] == "0")
            {
                labyrinth[position.X, position.Y + 1] = (value + 1).ToString();
                queue.Enqueue(new Position(position.X, position.Y + 1));
            }

            if (IsInRange(new Position(position.X - 1, position.Y), labyrinth) && labyrinth[position.X - 1, position.Y] == "0")
            {
                labyrinth[position.X - 1, position.Y] = (value + 1).ToString();
                queue.Enqueue(new Position(position.X - 1, position.Y));
            }

            if (IsInRange(new Position(position.X, position.Y - 1), labyrinth) && labyrinth[position.X, position.Y - 1] == "0")
            {
                labyrinth[position.X, position.Y - 1] = (value + 1).ToString();
                queue.Enqueue(new Position(position.X, position.Y - 1));
            }
        }

        private static bool IsInRange(Position position, string[,] labyrinth)
        {
            if (position.X > labyrinth.GetLength(0) - 1 || position.X < 0)
            {
                return false;
            }
            if (position.Y > labyrinth.GetLength(1) - 1 || position.Y < 0)
            {
                return false;
            }

            return true;
        }

        private static void FillUnreachableCells(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = "u";
                    }
                }
            }
        }

        private static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(" {0} ", labyrinth[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            string[,] labyrinth = new string[6, 6]
                {
                    { "0", "0", "0", "x", "0", "x"},
                    { "0", "x", "0", "x", "0", "x"},
                    { "0", "*", "x", "0", "x", "0"},
                    { "0", "x", "0", "0", "0", "0"},
                    { "0", "0", "0", "x", "x", "0"},
                    { "0", "0", "0", "x", "0", "x"},
                };
            Console.WriteLine("Before:");
            PrintLabyrinth(labyrinth);

            Console.WriteLine("After:");
            FillLabyrinth(labyrinth);
            PrintLabyrinth(labyrinth);
        }
    }
}
