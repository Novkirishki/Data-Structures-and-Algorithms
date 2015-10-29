//Implement the ADT stack as auto-resizable array.
//Resize the capacity on demand (when no space is available to add / insert a new element).

namespace _12.Stack
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            // The initial value of the array is 4. If we add 5 elements it should resize to 8.
            var stack = new Stack<int>();

            Console.WriteLine("Adding 1,2,3,4,5");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("Peeking last added number: {0}", stack.Peek());
            Console.WriteLine("Popping number: {0}", stack.Pop());
            Console.WriteLine("Popping number: {0}", stack.Pop());
            Console.WriteLine("Peeking number: {0}", stack.Peek());

            Console.WriteLine("Pushing number 6");
            stack.Push(6);

            Console.WriteLine("Peeking number: {0}", stack.Peek());
        }
    }
}
