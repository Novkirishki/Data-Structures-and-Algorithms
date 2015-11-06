//* Write a program to generate all permutations with repetitionsof given multi-set.
// Example: the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
//  { 1, 3, 5, 5 }  { 1, 5, 3, 5 }
//  { 1, 5, 5, 3 }  { 3, 1, 5, 5 }
//  { 3, 5, 1, 5 }  { 3, 5, 5, 1 }
//  { 5, 1, 3, 5 }  { 5, 1, 5, 3 }
//  { 5, 3, 1, 5 }  { 5, 3, 5, 1 }
//  { 5, 5, 1, 3 }  { 5, 5, 3, 1 }
//Ensure your program efficiently avoids duplicated permutations.
//Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.

namespace _11.PermutationsWithRepetitions
{
    public class Startup
    {
        public static void Main()
        {
            var set = new int[] { 1, 3, 5, 5 };

            PermutationsGenerator.Generate(set);

            var set2 = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            PermutationsGenerator.Generate(set2);
        }
    }
}
