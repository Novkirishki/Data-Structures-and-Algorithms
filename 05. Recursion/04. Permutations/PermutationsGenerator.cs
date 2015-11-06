namespace _04.Permutations
{
    using System;

    public static class PermutationsGenerator
    {
        public static void Generate(int n)
        {
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            RecursiveGeneration(0, numbers);
        }

        private static void RecursiveGeneration(int startingPosition, int[] numbers)
        {
            if (startingPosition == numbers.Length)
            {
                Print(numbers);
            }

            for (int i = startingPosition; i < numbers.Length; i++)
            {
                Swap(startingPosition, i, numbers);
                RecursiveGeneration(startingPosition + 1, numbers);
                Swap(startingPosition, i, numbers);
            }
        }

        private static void Swap(int start, int end, int[] array)
        {
            var buffer = array[end];
            array[end] = array[start];
            array[start] = buffer;
        }

        public static void Print(int[] numbers)
        {
            Console.WriteLine("({0})", string.Join(" ", numbers));
        }
    }
}
