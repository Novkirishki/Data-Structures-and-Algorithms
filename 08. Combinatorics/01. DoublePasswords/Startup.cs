namespace _01.DoublePasswords
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // read the input
            var input = Console.ReadLine();

            // count the number of *
            var numberOfStars = 0;
            foreach (var symbol in input)
            {
                if (symbol == '*')
                {
                    ++numberOfStars;
                }
            }

            // count the number of possible passwords
            long result = 1;
            for (int i = 0; i < numberOfStars; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
