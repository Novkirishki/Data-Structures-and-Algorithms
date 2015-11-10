//Write a program for generating and printing all subsets of k strings from given set of strings.
//Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)

namespace _06.StringCombinationsWithoutDuplicates
{
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            CombinationsGenerator.Generate(2, 0, new string[] { "test", "rock", "fun" });
        }
    }
}
