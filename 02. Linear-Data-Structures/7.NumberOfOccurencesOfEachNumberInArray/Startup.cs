//Write a program that finds in given array of integers(all belonging to the range[0..1000]) how many times each of them occurs.
//Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
//2 → 2 times
//3 → 4 times
//4 → 3 times

namespace _7.NumberOfOccurencesOfEachNumberInArray
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static void ShowOccurences(int[] array)
        {
            var numbers = new Dictionary<int, int>();

            foreach (var number in array)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            foreach (var pair in numbers)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }

        public static void Main()
        {
            int[] array = new int[9] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            ShowOccurences(array);
        }
    }
}
