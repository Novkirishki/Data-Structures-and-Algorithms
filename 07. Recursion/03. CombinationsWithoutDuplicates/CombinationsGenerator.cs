namespace _03.CombinationsWithoutDuplicates
{
    using System;

    public static class CombinationsGenerator
    {
        public static void Generate(int iterations, int[] combination, int depthLevel = 1, int startingPosition = 1)
        {
            if (depthLevel - 1 == combination.Length)
            {
                PrintCombination(combination);
                return;
            }

            for (int i = startingPosition; i <= iterations; i++)
            {
                combination[depthLevel - 1] = i;
                Generate(iterations, combination, depthLevel + 1, i + 1);
            }

        }

        public static void PrintCombination(int[] combination)
        {
            Console.WriteLine("({0})", string.Join(" ", combination));
        }
    }
}
