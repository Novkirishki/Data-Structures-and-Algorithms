namespace _02.ColorfulRabbits
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            // read the input
            var numberOfAskedRabbits = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();
            for (int i = 0; i < numberOfAskedRabbits; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(number))
                {
                    ++dict[number];
                }
                else
                {
                    dict[number] = 1;
                }
            }

            // calculate the rabbits
            long rabbits = 0;
            foreach (var pair in dict)
            {
                var multiplier = pair.Value / (pair.Key + 1);
                if (pair.Value % (pair.Key + 1) != 0)
                {
                    ++multiplier;
                }

                rabbits += (pair.Key + 1) * multiplier;
            }

            Console.WriteLine(rabbits);
        }
    }
}
