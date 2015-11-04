namespace _5.HashSet
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var set = new HashSet<int>();            
            set.Add(11);
            set.Add(10);

            var set2 = new HashSet<int>();
            set2.Add(10);

            var set3 = set.IntersectWith(set2);

            foreach (var item in set3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
