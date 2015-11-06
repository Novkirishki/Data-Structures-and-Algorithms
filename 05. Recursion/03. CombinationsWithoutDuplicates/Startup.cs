//Modify the previous program to skip duplicates:
//n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

namespace _03.CombinationsWithoutDuplicates
{
    public class Startup
    {
        public static void Main()
        {
            int elementsCount = 2;
            int setCount = 4;
            CombinationsGenerator.Generate(setCount, new int[elementsCount]);
        }
    }
}
