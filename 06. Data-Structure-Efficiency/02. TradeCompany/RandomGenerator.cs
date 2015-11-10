namespace _02.TradeCompany
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            var length = this.GetRandomNumber(minLength, maxLength);

            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        //Range is around 68 years.
        public DateTime GetRandomDate(DateTime start, DateTime end)
        {
            var range = (end - start).TotalSeconds;
            var timeToAdd = this.GetRandomNumber(0, (int)range);

            return start.AddSeconds(timeToAdd);
        }
    }
}

