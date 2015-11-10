//Implement a class BiDictionary<K1, K2, T> that allows adding triples { key1, key2, value }
//and fast search by key1, key2 or by both key1 and key2.
//Note: multiple values can be stored for given key.

namespace _03.BiDictionary
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dictionary = new BiDictionary<int, char, string>();
            dictionary.Add(1, 'a', "pesho");
            dictionary.Add(2, 'b', "gosho");
            dictionary.Add(1, 'c', "ivancho");
            dictionary.Add(3, 'c', "mariika");

            // searching by first key
            var firstKey = 1;
            var resultsByFirstKey = dictionary.Search(firstKey);
            Console.WriteLine("All values with first key: {0}", firstKey);
            foreach (var value in resultsByFirstKey)
            {
                Console.WriteLine(value);
            }

            // searching by second key
            var secondKey = 'c';
            var resultsBySecondKey = dictionary.Search(secondKey);
            Console.WriteLine("All values with second key: {0}", secondKey);
            foreach (var value in resultsBySecondKey)
            {
                Console.WriteLine(value);
            }

            // searching by both keys
            var resultsByBothKeys = dictionary.Search(firstKey, secondKey);
            Console.WriteLine("All values with first key {0} and second key {1}", firstKey, secondKey);
            foreach (var value in resultsByBothKeys)
            {
                Console.WriteLine(value);
            }
        }
    }
}
