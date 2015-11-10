namespace _01.PriorityQueue
{
    using System.Collections;

    public interface IPriorityQueue<T> : IEnumerable
    {
        void Enqueue(T item);

        T Dequeue();

        T Peek();

        void Clear();
    }
}
