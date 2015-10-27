//Write a program that removes from given sequence all negative numbers.

namespace _5.RemoveNegativeNumbers
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<int> RemoveNegativeNumbers(List<int> sequence)
        {
            var positiveSequence = new List<int>();

            foreach (var number in sequence)
            {
                if (number > 0)
                {
                    positiveSequence.Add(number);
                }
            }

            return positiveSequence;
        }

        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();
            var nonNegativeSequence = RemoveNegativeNumbers(sequence);
            Console.WriteLine("Sequence with removed negatives:");
            Console.WriteLine(string.Join(",", nonNegativeSequence));
        }
    }
}
