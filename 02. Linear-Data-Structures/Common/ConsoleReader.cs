namespace Common
{
    using System;
    using System.Collections.Generic;

    public static class ConsoleReader
    {
        public static List<int> ReadSequence()
        {
            var line = Console.ReadLine();
            var sequence = new List<int>();

            while (!string.IsNullOrEmpty(line))
            {
                var numbersAsString = line.Trim().Split(new char[] { ' ' });
                foreach (var number in numbersAsString)
                {
                    sequence.Add(int.Parse(number));
                }

                line = Console.ReadLine();
            }

            return sequence;
        }
    }
}
