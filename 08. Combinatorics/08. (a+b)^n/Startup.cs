namespace _08._a_b__n
{
    using System;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        private static string NumberOnPower(char number, int power)
        {
            if (power > 0)
            {
                return string.Format("({0}^{1})", number, power);
            }

            return "";
        }

        private static BigInteger CalculateBinom(int a, int b)
        {
            BigInteger result = 1;
            for (int i = b + 1; i <= a; i++)
            {
                result *= i;
            }

            for (int i = 1; i <= a - b; i++)
            {
                result /= i;
            }

            return result;
        }

        public static void Main()
        {
            var input = Console.ReadLine();
            var firstChar = input[1];
            var secondChar = input[3];
            Console.ReadLine();

            var power = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = 0; i < power + 1; i++)
            {
                var coef = CalculateBinom(power, Math.Abs(power - i));
                var first = NumberOnPower(firstChar, power - i);
                var second = NumberOnPower(secondChar, i);

                if (coef != 1)
                {
                    builder.Append(coef);
                }

                builder.Append(first + second + "+");
            }

            builder.Remove(builder.Length - 1, 1);
            Console.WriteLine(builder);
        }
    }
}
