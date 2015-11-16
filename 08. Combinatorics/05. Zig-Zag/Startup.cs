namespace _05.Zig_Zag
{
    using System;

    public class Startup
    {
        public static int count = 0;

        public static void Main()
        {
            var input = Console.ReadLine();
            var values = input.Split(new char[] { ' ' });
            var numbers = int.Parse(values[0]);
            var len = int.Parse(values[1]);

            int[] arr = new int[numbers];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
            }

            GenerateSequence(len, true, arr, -1);
            Console.WriteLine(count);
        }

        private static void GenerateSequence(int currentPosition, bool IsBig, int[] arr, int previousNumber)
        {
            if (currentPosition == 0)
            {
                ++count;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != 0)
                    {
                        if (IsBig)
                        {
                            if (i > previousNumber)
                            {
                                arr[i] = 0;
                                GenerateSequence(currentPosition - 1, false, arr, i);
                                arr[i] = 1;
                            }
                        }
                        else
                        {
                            if (i < previousNumber)
                            {
                                arr[i] = 0;
                                GenerateSequence(currentPosition - 1, true, arr, i);
                                arr[i] = 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
