using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shit
{
    class Program
    {
        private static List<string> combinations;

        private static  void GenerateCombination(int lastDigit, int passLen, string command, int currentIndex, int[] currentCombination = null)
        {
            if (currentCombination == null)
            {
                currentCombination = new int[passLen];
            }

            if (currentCombination.Length == currentIndex)
            {
                combinations.Add(currentCombination.ToString());
                return;
            }

            if (command[currentIndex] == '=')
            {
                currentCombination[currentIndex] = lastDigit;
                GenerateCombination(lastDigit, passLen, command, currentIndex + 1, currentCombination);
            }
            else if(command[currentIndex] == '<')
            {
                for (int i = 1; i < lastDigit; i++)
                {
                    currentCombination[currentIndex] = i;
                    GenerateCombination(lastDigit, passLen, command, currentIndex + 1, currentCombination);
                }
            }
            else if(command[currentIndex] == '>')
            {
                for (int i = lastDigit; i <= 10; i++)
                {
                    if (i == 10)
                    {
                        currentCombination[currentIndex] = 0;
                        GenerateCombination(lastDigit, passLen, command, currentIndex + 1, currentCombination);
                    }

                    currentCombination[currentIndex] = i;
                    GenerateCombination(lastDigit, passLen, command, currentIndex + 1, currentCombination);
                }
            }
        }

        static void Main(string[] args)
        {
            combinations = new List<string>();
            var passwordLength = int.Parse(Console.ReadLine());
            var expression = Console.ReadLine();
            var numberOfCombination = int.Parse(Console.ReadLine());

            GenerateCombination(-1, passwordLength, expression, 0);

            Console.WriteLine(combinations[numberOfCombination]);
        }
    }
}
