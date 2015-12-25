using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        private static int MaxDeviation(string expression)
        {
            int currentDeviation = 0;
            int currentMin = 0;
            int currentMax = 0;
            foreach (var letter in expression)
            {
                if (letter == '<')
                {
                    currentDeviation -= 1;
                }
                else if (letter == '>')
                {
                    currentDeviation += 1;
                }

                if (currentDeviation < currentMin)
                {
                    currentMin = currentDeviation;
                }

                if (currentDeviation > currentMax)
                {
                    currentMax = currentDeviation;
                }
            }

            return 10 - currentMax + currentMin;
        }

        private static int NumberOfDigitChanges(string expression)
        {
            var count = 0;
            foreach (var letter in expression)
            {
                if (letter == '<' || letter == '>')
                {
                    count++;
                }
            }

            return count + 1;
        }

        private static int DetermineNumberOfLettersToBeNotMin(int maxDeviation, int numberOfChanges, int numberOfCombination)
        {
            for (int i = 0; i <= numberOfChanges; i++)
            {
                if (Math.Pow(i, maxDeviation) > numberOfCombination)
                {
                    return i;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            var passwordLength = int.Parse(Console.ReadLine());
            var expression = Console.ReadLine();
            var numberOfCombination = int.Parse(Console.ReadLine());

            var maxDeviation = MaxDeviation(expression);
            var numberOfChanges = NumberOfDigitChanges(expression);

            Console.WriteLine(DetermineNumberOfLettersToBeNotMin(maxDeviation, numberOfChanges, numberOfCombination));
        }
    }
}
