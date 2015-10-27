//Write a program that reads from the console a sequence of positive integer numbers.
//The sequence ends when empty line is entered.
//Calculate and print the sum and average of the elements of the sequence.
//Keep the sequence in List<int>.

namespace _1.SumAndAverageOfSequence
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static double FindSum(List<int> sequence)
        {
            double sum = 0;

            foreach (var number in sequence)
            {
                sum += number;
            }

            return sum;
        }

        private static double FindAverage(List<int> sequence)
        {
            double sum = FindSum(sequence);

            return sum / sequence.Count;
        }

        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();

            Console.WriteLine("The sum of the sequence is {0}", FindSum(sequence));
            Console.WriteLine("The average of the sequence is {0}", FindAverage(sequence));
        }
    }
}
