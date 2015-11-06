namespace _05.Variations
{
    using System;
    using System.Collections.Generic;

    public static class VariationsGenerator
    {
        public static void Generate(int k, List<string> set, string[] variation = null)
        {
            if (variation == null)
            {
                variation = new string[k];
            }

            if (k == 0)
            {
                Print(variation);
                return;
            }

            for (int i = 0; i < set.Count; i++)
            {
                variation[k - 1] = set[i];
                Generate(k - 1, set, variation);
            }

        }

        private static void Print(string[] arr)
        {
            Console.WriteLine("({0})", string.Join(" ", arr));
        }
    }
}
