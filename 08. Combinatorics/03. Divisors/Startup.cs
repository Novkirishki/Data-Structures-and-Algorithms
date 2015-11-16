namespace _03.Divisors
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static void PermuteRep(int[] arr, int start, int n, HashSet<int> permutations)
        {
            permutations.Add(MakeArrayToNumber(arr));
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        var buff = arr[left];
                        arr[left] = arr[right];
                        arr[right] = buff;
                        PermuteRep(arr, left + 1, n, permutations);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }

        private static int MakeArrayToNumber(int[] arr)
        {
            var number = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                number += (arr[i] * (int) Math.Pow(10, arr.Length - i - 1));
            }

            return number;
        }

        private static int CalculateDivisors(int number)
        {
            var count = 2;
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    ++count;
                }
            }

            return count;
        }

        public static void Main()
        {
            var numberOfDigits = int.Parse(Console.ReadLine());

            var digits = new int[numberOfDigits];
            for (int i = 0; i < numberOfDigits; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(digits);
            var allNumbers = new HashSet<int>();
            PermuteRep(digits, 0, digits.Length, allNumbers);

            var numbersWithMinNumberOfDivisors = new SortedSet<int>();
            var minCountOfDivisors = 10000;
            foreach (var number in allNumbers)
            {
                var divisorsCount = CalculateDivisors(number);
                if (divisorsCount < minCountOfDivisors)
                {
                    numbersWithMinNumberOfDivisors.Clear();
                    numbersWithMinNumberOfDivisors.Add(number);
                    minCountOfDivisors = divisorsCount;
                }
                else if (divisorsCount == minCountOfDivisors)
                {
                    numbersWithMinNumberOfDivisors.Add(number);
                }
            }

            Console.WriteLine(numbersWithMinNumberOfDivisors.Min);
        }
    }
}
