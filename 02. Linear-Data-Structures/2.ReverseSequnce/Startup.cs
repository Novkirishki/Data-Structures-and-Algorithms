//Write a program that reads N integers from the console and reverses them using a stack.
//Use the Stack<int> class.

namespace _2.ReverseSequnce
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static Stack<int> ReadSequence()
        {
            var line = Console.ReadLine();
            var sequence = new Stack<int>();

            while (!string.IsNullOrEmpty(line))
            {
                var numbersAsString = line.Trim().Split(new char[] { ' ' });
                foreach (var number in numbersAsString)
                {
                    sequence.Push(int.Parse(number));
                }

                line = Console.ReadLine();
            }

            return sequence;
        }

        private static List<int> ReverseSequnce(Stack<int> sequence)
        {
            var numbers = new List<int>();

            foreach (var number in sequence)
            {
                numbers.Add(number);
            }

            return numbers;
        }

        public static void Main()
        {
            var sequence = ReadSequence();
            var reversedSequence = ReverseSequnce(sequence);

            Console.WriteLine("The sequence reversed:");
            Console.WriteLine(string.Join(",", sequence));
        }
    }
}
