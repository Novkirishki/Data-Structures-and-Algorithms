namespace _02.ProductsSearcher
{
    using System.Collections.Generic;

    public class ProductsGenerator
    {
        public static List<Product> Generate(int count)
        {
            var products = new List<Product>();
            var generator = RandomGenerator.Instance;

            for (int i = 0; i < count; i++)
            {
                var name = generator.GetRandomString(5, 20);
                var price = generator.GetRandomNumber(1, 200000);
                var product = new Product(name, price);
                products.Add(product);
            }

            return products;
        }
    }
}
