using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var moves = Console.ReadLine().Split(' ').Select(int.Parse);
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var table = new bool[sizes[1] + 1];

            table[0] = true;
            foreach (var move in moves)
            {
                table[move] = true;
            }

            for (int i = 1; i < table.Length; i++)
            {
                if (table[i] == false)
                {
                    foreach (var move in moves)
                    {
                        if (i - move > 0 && table[i - move] == false)
                        {
                            table[i] = true;
                        }
                    }
                }
            }

            int counter = 0;
            for (int i = sizes[0]; i < table.Length; i++)
            {
                if (table[i] == true)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
