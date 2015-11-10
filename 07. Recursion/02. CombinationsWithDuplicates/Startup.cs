//Write a recursive program for generating and printing all the combinations 
//    with duplicatesof k elements from n-element set.Example:
//n= 3, k= 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

namespace _02.CombinationsWithDuplicates
{
    public class Startup
    {
        public static void Main()
        {
            int elementsCount = 2;
            int setCount = 3;
            CombinationsGenerator.Generate(setCount, new int[elementsCount]);
        }
    }
}
