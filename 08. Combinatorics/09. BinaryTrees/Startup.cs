namespace _09.BinaryTrees
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Startup
    {
        private static long[] memo;

        private static BigInteger CalculateBinom(int a, int b)
        {
            BigInteger result = 1;
            for (int i = b + 1; i <= a; i++)
            {
                result *= i;
            }

            for (int i = 1; i <= a - b; i++)
            {
                result /= i;
            }

            return result;
        }

        private static long Trees(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Trees(i) * Trees(n - i - 1);
            }

            memo[n] = result;
            return result;
        }

        public static void Main()
        {
            var balls = Console.ReadLine();

            memo = new long[21];
            var trees = Trees(balls.Length);

            var dict = new Dictionary<char, int>();

            foreach (var ball in balls)
            {
                if (dict.ContainsKey(ball))
                {
                    ++dict[ball];
                }
                else
                {
                    dict[ball] = 1;
                }
            }

            BigInteger numberOfPermutations = 1;
            var positionsCount = balls.Length;

            foreach (var pair in dict)
            {
                numberOfPermutations *= CalculateBinom(positionsCount, pair.Value);
                positionsCount -= pair.Value;
            }

            Console.WriteLine(trees * numberOfPermutations);
        }
    }
}
