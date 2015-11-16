namespace _06.SubSequenceSum
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        private static BigInteger CalculateBinom(int a, int b)
        {
            BigInteger result = 1;
            for (int i = b + 1; i <= a; i++)
            {
                result *= i;
            }

            for (int i = 1; i <= a - b; i++)
            {
                result /= i;
            }

            return result;
        }

        public static void Main()
        {
            var tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                var values = Console.ReadLine().Split(new char[] { ' ' });
                var countOfNumbers = int.Parse(values[0]);
                var countOfRemovedNumbers = int.Parse(values[1]);
                var combinations = CalculateBinom(countOfNumbers, countOfRemovedNumbers);

                var sequence = Console.ReadLine().Split(new char[] { ' ' });
                var sumOfSequence = sequence.Sum(n => int.Parse(n));

                Console.WriteLine(sumOfSequence * ((combinations *  (countOfNumbers - countOfRemovedNumbers)) / countOfNumbers));
            }
        }
    }
}
