//We are given the following sequence:

//S1 = N;
//S2 = S1 + 1;
//S3 = 2* S1 + 1;
//S4 = S1 + 2;
//S5 = S2 + 1;
//S6 = 2* S2 + 1;
//S7 = S2 + 2;
//...
//Using the Queue<T> class write a program to print its first 50 members for given N.
//Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace _9.GenerateSequence
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static List<int> GenerateSequence(int n, int count)
        {
            var queue = new Queue<int>();
            queue.Enqueue(n);

            var sequence = new List<int>();
            sequence.Add(n);

            for (int i = 1; i < count; i++)
            {
                var number = 0;

                if (i % 3 == 1)
                {
                    number = queue.Peek() + 1;
                }
                else if (i % 3 == 2)
                {
                    number = queue.Peek() * 2 + 1;
                }
                else
                {
                    number = queue.Dequeue() + 2;
                }


                sequence.Add(number);
                queue.Enqueue(number);
            }

            return sequence;
        }

        public static void Main()
        {
            Console.WriteLine("Insert a number n: ");
            var n = int.Parse(Console.ReadLine());

            var sequence = GenerateSequence(n, 50);

            Console.WriteLine("The generated sequence is:");
            Console.WriteLine(string.Join(",", sequence));
        }
    }
}
