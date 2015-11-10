//Write a program that finds a set of words(e.g. 1000 words) in a large text(e.g. 100 MB text file).
//Print how many times each word occurs in the text.
//Hint: you may find a C# trie in Internet.

namespace _03.WordsFinder
{
    using System;
    using System.IO;
    using System.Linq;
    using Triepocalypse;

    public class Startup
    {
        private static void GenerateLargeFile(string filename)
        {
            var text = File.ReadAllText("..\\..\\text.txt");

            for (int i = 0; i < 100; i++)
            {
                File.AppendAllText(filename, text);
            }

            Console.WriteLine("Large file generated(size around 80 Mb)");
        }

        private static Trie<int> ParseFile(string filename)
        {
            Trie<int> trie = new Trie<int>();

            Console.WriteLine("Reading file and loading content in trie:");

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    reader
                        .ReadLine()
                        .Split(' ', '.', ',', '?', '!', ':')
                        .ToList()
                        .ForEach(word =>
                        {
                            if (!trie.ContainsKey(word))
                            {
                                trie.Add(word, 1);
                            }
                            else
                            {
                                trie[word] += 1;
                            }
                        });
                }
            }

            Console.WriteLine("File read and loaded into trie");

            return trie;
        }

        private static void PrintWordOccurrences(Trie<int> trie, string[] words)
        {
            foreach (var word in words)
            {
                trie.Matcher.Reset();
                trie.Matcher.Next(word);

                int countOfWord = 0;

                if (trie.Matcher.IsMatch())
                {
                    countOfWord = trie.Matcher.GetExactMatch();
                }

                Console.WriteLine("Count of \"{0}\" occurrences: {1}", word ,countOfWord);
            }
        }

        public static void Main()
        {
            GenerateLargeFile("..\\..\\large_text.txt"); // file is arond 80 Mb
            var trie = ParseFile("..\\..\\large_text.txt");

            var arrayOfWords = new string[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit" };

            PrintWordOccurrences(trie, arrayOfWords);
        }
    }
}
