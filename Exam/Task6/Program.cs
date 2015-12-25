using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Hash
    {
        private const ulong BASE = 257;
        private const ulong MOD = 1000000033;

        private static ulong[] powers;

        public static void ComputePowers(int n)
        {
            powers = new ulong[n + 1];
            powers[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers[i + 1] = powers[i] * BASE % MOD;
            }
        }

        public ulong Value { get; set; }

        public Hash(string str)
        {
            this.Value = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public Hash()
        {

        }

        public void Add(char c)
        {
            this.Value = (this.Value * BASE + c) % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value = (MOD + this.Value - powers[n] * c % MOD) % MOD;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigInteger count = 0;

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int n = text.Length;
            int m = pattern.Length;

            Hash.ComputePowers(m);

            var prefix = pattern.Substring(0, 1);
            var suffix = pattern.Substring(1, m - 1);

            Hash hprefix = new Hash(prefix);
            Hash hsuffix = new Hash(suffix);

            Hash hPrefixWindowGeneral = new Hash(text.Substring(0, 1));
            Hash hSuffixWindowGeneral = new Hash(text.Substring(0, m - 1));

            var suffixes = new List<Hash>();
            var prefixes = new List<Hash>();
            var hWindowsPrefixes = new List<Hash>();
            var hWindowSuffixes = new List<Hash>();

            for (int i = 1; i <= m; i++)
            {
                suffixes.Add(new Hash(pattern.Substring(0, i)));
                prefixes.Add(new Hash(pattern.Substring(i, m - i)));
                hWindowsPrefixes.Add(new Hash(text.Substring(0, i)));
                hWindowSuffixes.Add(new Hash(text.Substring(0, m - i)));
            }

            for (int i = 1; i <= n; i++)
            {
                hPrefixWindow.Add(text[i + j - 1]);
                hPrefixWindow.Remove(text[i - 1], j);

                if (hprefix.Value == hPrefixWindow.Value)
                {
                    prefixCount++;
                }
            }


            for (int j = 1; j <= m; j++)
            {
                long prefixCount = 0;
                long suffixCount = 0;

                Hash hPrefixWindow = new Hash();
                hPrefixWindow.Value = hPrefixWindowGeneral.Value;
                Hash hSuffixWindow = new Hash();
                hSuffixWindow.Value = hSuffixWindowGeneral.Value;

                if (hprefix.Value == hPrefixWindow.Value)
                {
                    prefixCount++;
                }

                if (hsuffix.Value == hSuffixWindow.Value)
                {
                    suffixCount++;
                }

                //for prefix
                for (int i = 1; i <= n - j; i++)
                {
                    hPrefixWindow.Add(text[i + j - 1]);
                    hPrefixWindow.Remove(text[i - 1], j);

                    if (hprefix.Value == hPrefixWindow.Value)
                    {
                        prefixCount++;
                    }
                }

                //for suffix
                if (j != m)
                {
                    for (int i = 1; i <= n - (m - j); i++)
                    {
                        hSuffixWindow.Add(text[i + (m - j) - 1]);
                        hSuffixWindow.Remove(text[i - 1], (m - j));

                        if (hsuffix.Value == hSuffixWindow.Value)
                        {
                            suffixCount++;
                        }
                    }
                }
                else
                {
                    suffixCount = 1;
                }

                count += (prefixCount * suffixCount);

                // change prefix and suffix hash
                if (m != j)
                {
                    hprefix.Add(pattern[j]);
                    hsuffix.Remove(pattern[j], m - j - 1);
                    hPrefixWindowGeneral.Add(text[j]);
                    hSuffixWindowGeneral.Remove(text[j], m - j - 1);
                }
            }

            Console.WriteLine(count);
        }
    }
}
