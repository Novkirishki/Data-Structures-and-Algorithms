namespace _06.StringCombinationsWithoutDuplicates
{
    using System;
    using System.Collections.Generic;

    public static class CombinationsGenerator
    {
        public static void Generate(int k, int startingPosition, string[] set, string[] combination = null)
        {
            if (combination == null)
            {
                combination = new string[k];
            }

            if (k == 0)
            {
                Print(combination);
                return;
            }

            for (int i = startingPosition; i < set.Length; i++)
            {
                combination[k - 1] = set[i];
                Generate(k - 1, i + 1, set, combination);
            }
        }

        private static void Print(string[] arr)
        {
            Console.WriteLine("({0})", string.Join(" ", arr));
        }
    }
}
