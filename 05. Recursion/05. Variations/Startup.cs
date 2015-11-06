//Write a recursive program for generating and printing all ordered k-element subsets from n-element set(variations Vkn).
//Example: n=3, k=2, set = {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

namespace _05.Variations
{
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            VariationsGenerator.Generate(2, new List<string>(){ "hi", "a", "b"});
        }
    }
}
