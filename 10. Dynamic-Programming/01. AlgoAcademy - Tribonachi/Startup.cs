namespace _01.AlgoAcademy___Tribonachi
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            var table = new BigInteger[input[3]];

            table[0] = input[0];
            table[1] = input[1];
            table[2] = input[2];

            for (int i = 3; i < input[3]; i++)
            {
                table[i] = table[i - 1] + table[i - 2] + table[i - 3];
            }

            Console.WriteLine(table[input[3] - 1]);
        }
    }
}
