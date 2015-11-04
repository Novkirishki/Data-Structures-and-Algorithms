namespace _4.HashTable
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var table = new HashTable<string, int>();
            table.Add("goshko", 12);
            table.Add("peshko", 13);
            table.Add("ivancho", 0);
            table.Add("aaa", 5);
            table["bbb"] = 6;
            table["ccc"] = 7;
            table.Remove("ccc");

            Console.WriteLine(table.Count);
            Console.WriteLine(table.Find("aaa"));

            foreach (KeyValuePair<string, int> pair in table)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            foreach (var key in table.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
