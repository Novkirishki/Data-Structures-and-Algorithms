using System;

namespace _12._8QueensPuzzle
{
    public class QueenSolver
    {
        public static void Solve(int boardSize, int currentQueen = 0, int[] queensColumns = null)
        {
            if (queensColumns == null)
            {
                queensColumns = new int[boardSize];
            }

            if (currentQueen == boardSize)
            {
                PrintBoard(queensColumns);
                return;
            }

            for (int i = 0; i < boardSize; i++)
            {
                if (IsLegit(i, currentQueen, queensColumns))
                {
                    queensColumns[currentQueen] = i;
                    Solve(boardSize, currentQueen + 1, queensColumns);
                }
            }
        }

        private static bool IsLegit(int queenColumn, int queensCount, int[] queensColumns)
        {
            for (int i = 0; i < queensCount; i++)
            {
                // checks for column
                if (queensColumns[i] == queenColumn)
                {
                    return false;
                }

                // checks for diagonal
                if (Math.Abs(queensColumns[i] - queenColumn) == Math.Abs(i - queensCount))
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintBoard(int[] queensColumns)
        {
            foreach (var col in queensColumns)
            {
                var emptyCellsBeforeQueen = new String('-', col);
                var emptyCellsAfterQueen = new String('-', queensColumns.Length - col - 1);
                Console.WriteLine(emptyCellsBeforeQueen + "Q" + emptyCellsAfterQueen);
            }

            Console.WriteLine();
        }
    }
}
