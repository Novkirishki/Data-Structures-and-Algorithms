//A large trade company has millions of articles, each described by barcode, vendor, title and price.
//Implement a data structure to store them that allows fast retrieval of all articles in given price range[x…y].
//Hint: use OrderedMultiDictionary<K, T> from Wintellect's Power Collections for .NET.

namespace _02.TradeCompany
{
    using System;
    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var articles = ArticlesGenerator.Generate(1000);
            var dictionary = new OrderedMultiDictionary<decimal, Article>(true);

            foreach (var article in articles)
            {
                dictionary.Add(article.Price, article);
            }

            // Gets articles in range from 100 to 130
            var articlesInRange = dictionary.Range(100, true, 130, true);

            foreach (var pair in articlesInRange)
            {
                Console.WriteLine(pair.Value);
            }
        }
    }
}
