//Write a recursive program for generating and printing all permutations 
//    of the numbers 1, 2, ..., n for given integer number n.Example:
//n= 3 → { 1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

namespace _04.Permutations
{
    public class Startup
    {
        public static void Main()
        {
            PermutationsGenerator.Generate(4);
        }
    }
}
