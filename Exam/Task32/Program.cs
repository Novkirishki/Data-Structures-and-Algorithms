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

            if (moves.ToArray().Length == 1 && sizes[0] == sizes[1])
            {
                Console.WriteLine(0);
                return;
            }

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
                        if (i + move < table.Length)
                        {
                            table[i + move] = true;
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
