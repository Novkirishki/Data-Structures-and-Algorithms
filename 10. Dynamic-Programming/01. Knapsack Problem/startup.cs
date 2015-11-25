//Write a program based on dynamic programming to solve the "Knapsack Problem":
//you are given N products, each has weight Wi and costs Ci and a knapsack of capacity 
//    M and you want to put inside a subset of the products with highest cost and weight ≤ M.
//    The numbers N, M, Wi and Ci are integers in the range[1..500].

//Example: M=10kg, N=6, products:
//beer – weight=3, cost=2
//vodka – weight=8, cost=12
//cheese – weight=4, cost=5
//nuts – weight=1, cost=4
//ham – weight=2, cost=3
//whiskey – weight=8, cost=13
//Optimal solution:
//nuts + whiskey
//weight = 9
//cost = 17

namespace _01.Knapsack_Problem
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var weights = new int[] { 3, 8, 4, 1, 2, 8};
            var costs = new int[] { 2, 12, 5, 4, 3, 13 };
            var maxWeight = 10;

            var table = new int[weights.Length, maxWeight];

            for (int row = 1; row < weights.Length; row++)
            {
                for (int col = 0; col < maxWeight; col++)
                {
                    if (weights[row] > col)
                    {
                        table[row, col] = table[row - 1, col];
                    }
                    else
                    {
                        if (table[row - 1, col] > costs[row] + table[row - 1, col - weights[row]])
                        {
                            table[row, col] = table[row - 1, col];
                        }
                        else
                        {
                            table[row, col] = costs[row] + table[row - 1, col - weights[row]];
                        }
                    }
                }
            }

            Console.WriteLine(table[table.GetLength(0) -1, table.GetLength(1) - 1]);
        }
    }
}
