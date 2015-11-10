//Implement a class PriorityQueue<T> based on the data structure "binary heap".

namespace _01.PriorityQueue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var minPriorityQueue = new PriorityQueue<int>();

            minPriorityQueue.Enqueue(12);
            minPriorityQueue.Enqueue(3);
            minPriorityQueue.Enqueue(7);

            Console.WriteLine(minPriorityQueue.Dequeue());
            Console.WriteLine(minPriorityQueue.Dequeue());
            Console.WriteLine(minPriorityQueue.Dequeue());
        }
    }
}
