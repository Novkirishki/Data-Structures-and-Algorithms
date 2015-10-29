//Implement the ADT queue as dynamic linked list.
//Use generics(LinkedQueue<T>) to allow storing different data types in the queue.

namespace _13.Queue
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var queue = new Queue<int>();

            Console.WriteLine("Adding 1,2,3,4,5");
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine("Peeking first added number: {0}", queue.Peek());
            Console.WriteLine("Dequeuing number: {0}", queue.Dequeue());
            Console.WriteLine("Dequeuing number: {0}", queue.Dequeue());
            Console.WriteLine("Peeking number: {0}", queue.Peek());

            Console.WriteLine("Enqueueing number 6");
            queue.Enqueue(6);

            Console.WriteLine("Peeking number: {0}", queue.Peek());
        }
    }
}
