// Write a program that extracts from a given sequence of strings all 
// elements that present in it odd number of times.

namespace _2.StringExtractor
{
    using System;
    using System.Collections.Generic;

    public class Stratup
    {
        private static ICollection<string> ExtractStrings(string[] arr)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var str in arr)
            {
                if (dictionary.ContainsKey(str))
                {
                    ++dictionary[str];
                }
                else
                {
                    dictionary.Add(str, 1);
                }
            }

            var result = new List<string>();

            foreach (var pair in dictionary)
            {
                if (pair.Value % 2 == 1)
                {
                    result.Add(pair.Key);
                }
            }

            return result;
        }

        private static void PrintStrings(ICollection<string> values)
        {
            Console.Write("{");
            Console.Write(string.Join(",", values));
            Console.WriteLine("}");
        }

        public static void Main()
        {
            var arr = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var values = ExtractStrings(arr);
            PrintStrings(values);
        }
    }
}
