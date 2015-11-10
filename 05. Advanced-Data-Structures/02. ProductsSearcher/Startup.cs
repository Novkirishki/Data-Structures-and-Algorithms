//Write a program to read a large collection of products(name + price) and 
//    efficiently find the first 20 products in the price range[a…b].
//Test for 500 000 products and 10 000 price searches.
//Hint: you may use OrderedBag<T> and sub-ranges.

namespace _02.ProductsSearcher
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private static void PrintProductsInRange(int start, int end, OrderedBag<Product> products)
        {
            var result = products.Range(new Product("a", start), true, new Product("b", end), true).Take(20);

            foreach (var product in result)
            {
                Console.WriteLine(product);
            }
        }

        private static void MakeSearches(int count, int start, int end, OrderedBag<Product> products)
        {
            for (int i = 0; i < count; i++)
            {
                var result = products.Range(new Product("a", start), true, new Product("b", end), true).Take(20);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                }
            }
        }

        public static void Main()
        {
            var bag = new OrderedBag<Product>();

            var products = ProductsGenerator.Generate(500000);

            bag.AddMany(products);

            PrintProductsInRange(20, 1000, bag);

            MakeSearches(10000, 1, 5000, bag);
        }
    }
}
