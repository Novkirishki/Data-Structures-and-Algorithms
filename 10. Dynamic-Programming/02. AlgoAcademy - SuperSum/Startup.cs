namespace _02.AlgoAcademy___SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            var table = new int[input[0] + 1, input[1] + 1];

            for (int i = 0; i <= input[1]; i++)
            {
                table[0, i] = i;
            }

            for (int row = 1; row <= input[0]; row++)
            {
                for (int col = 0; col <= input[1]; col++)
                {
                    for (int k = 0; k <= col; k++)
                    {
                        table[row, col] += table[row - 1, k];
                    } 
                }
            }

            Console.WriteLine(table[input[0], input[1]]);
        }
    }
}
