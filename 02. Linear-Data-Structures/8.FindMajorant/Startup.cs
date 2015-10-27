//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
// Write a program to find the majorant of given array(if exists).
//Example:
//{2, 2, 3, 3, 2, 3, 4, 3, 3} → 3

using System;
using System.Collections.Generic;

namespace _8.FindMajorant
{
    public class Startup
    {
        private static void FindMajorant(int[] array)
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
                if (pair.Value >= array.Length / 2 + 1)
                {
                    Console.WriteLine("The majorant is {0}", pair.Key);
                    return;
                }
            }

            Console.WriteLine("There is no majorant");
        }

        public static void Main()
        {
            int[] array = new int[9] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            FindMajorant(array);
        }
    }
}
