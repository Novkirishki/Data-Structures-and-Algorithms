//Write a program that removes from given sequence all numbers that occur odd number of times.
//Example:
//{ 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}

namespace _6.RemoveNumbersOccuringOddTimes
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static List<int> RemoveOddTimesOccuringNumbers(List<int> sequence)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var number in sequence)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                {
                    dictionary.Add(number, 1);
                }
            }

            foreach (var pair in dictionary)
            {
                if (pair.Value % 2 != 0)
                {
                    sequence.RemoveAll(x => x == pair.Key);
                }
            }

            return sequence;
        }

        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();
            var newSequence = RemoveOddTimesOccuringNumbers(sequence);
            Console.WriteLine("The new sequence after all numbers occuring odd number of time are removed");
            Console.WriteLine(string.Join(",", newSequence));
        }
    }
}
