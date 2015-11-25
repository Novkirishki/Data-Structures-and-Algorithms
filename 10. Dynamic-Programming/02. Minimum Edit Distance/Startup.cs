namespace _02.Minimum_Edit_Distance
{
    using System;

    public class Startup
    {
        private static int GetMin(int a, int b, int c)
        {
            if (a < b && a < c)
            {
                return a;
            }
            else if (b < c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        public static void Main()
        {
            var stringA = "developer";
            var stringB = "enveloped";

            var table = new int[stringA.Length + 1, stringB.Length + 1];
            table[0, 0] = 0;

            for (int i = 1; i < table.GetLength(0); i++)
            {
                table[i, 0] = i;
            }

            for (int i = 1; i < table.GetLength(1); i++)
            {
                table[0, i] = i;
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (stringA[row - 1] == stringB[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        var min = GetMin(table[row - 1, col - 1], table[row, col - 1], table[row - 1, col]);
                        table[row, col] = min + 1;
                    }
                }
            }

            Console.WriteLine(table[table.GetLength(0) - 1, table.GetLength(1) - 1]);
        }
    }
}
