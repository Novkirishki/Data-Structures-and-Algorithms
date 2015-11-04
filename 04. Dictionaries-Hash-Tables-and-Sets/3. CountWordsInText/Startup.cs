// Write a program that counts how many times each word from given text file words.
// txt appears in it.The character casing differences should be ignored.
// The result words should be ordered by their number of occurrences in the text.

namespace _3.CountWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Specialized;

    public class Startup
    {
        private static Dictionary<string, int> CountWordsOccurences(string text)
        {
            var dictionary = new Dictionary<string, int>();
            var words = text.Split(new char[] { ' ', '.', ':', '!', ',', '?', ';', '-', '_', '–' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var currentWord = word.ToLower();
                
                if (dictionary.ContainsKey(currentWord))
                {
                    ++dictionary[currentWord];
                }
                else
                {
                    dictionary.Add(currentWord, 1);
                }
            }

            return dictionary.OrderBy(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
        }

        private static void PrintWordsCount(Dictionary<string, int> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }

        public static void Main()
        {
            var text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var dict = CountWordsOccurences(text);
            PrintWordsCount(dict);
        }
    }
}
