//Write a program that counts in a given array of double values the number 
//of occurrences of each value.Use Dictionary<TKey, TValue>.

namespace _1.OccurencesCount
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {   
        private static Dictionary<double, int> CountOccurences(double[] arr)
        {
            var dictionary = new Dictionary<double, int>();

            foreach (var number in arr)
            {
                if (dictionary.ContainsKey(number))
                {
                    ++dictionary[number];
                }
                else
                {
                    dictionary.Add(number, 1);
                }
            }

            return dictionary;
        }

        private static void PrintNumbersCount(Dictionary<double, int> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }

        public static void Main()
        {
            double[] arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dict = CountOccurences(arr);
            PrintNumbersCount(dict);
        }
    }
}
