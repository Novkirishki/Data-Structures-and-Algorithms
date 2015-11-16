namespace _04.ColorBalls
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;

    public class Startup
    {
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

        public static void Main()
        {
            var balls = Console.ReadLine();
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

            Console.WriteLine(numberOfPermutations);
        }
    }
}
