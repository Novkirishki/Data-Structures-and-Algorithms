//Write a program that reads a sequence of integers(List<int>) 
//ending with an empty line and sorts them in an increasing order.

namespace _3.SortSequence
{
    using Common;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var sequence = ConsoleReader.ReadSequence();
            sequence.Sort();
            Console.WriteLine("The sorted sequece:");
            Console.WriteLine(string.Join(",", sequence));
        }
    }
}
