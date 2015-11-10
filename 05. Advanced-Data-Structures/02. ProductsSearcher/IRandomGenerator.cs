namespace _02.ProductsSearcher
{
    using System;

    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int minLength, int maxLength);
    }
}
