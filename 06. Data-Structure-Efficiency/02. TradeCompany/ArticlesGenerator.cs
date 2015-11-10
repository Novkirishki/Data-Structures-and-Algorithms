namespace _02.TradeCompany
{
    using System.Collections.Generic;

    public class ArticlesGenerator
    {
        public static ICollection<Article> Generate(int count)
        {
            var generator = RandomGenerator.Instance;
            var articles = new HashSet<Article>();

            for (int i = 0; i < count; i++)
            {
                articles.Add(new Article()
                {
                    Title = generator.GetRandomString(3, 20),
                    Barcode = generator.GetRandomString(17, 17),
                    Vendor = generator.GetRandomString(2, 15),
                    Price = generator.GetRandomNumber(1, 2000)
                });
            }

            return articles;
        } 
    }
}
