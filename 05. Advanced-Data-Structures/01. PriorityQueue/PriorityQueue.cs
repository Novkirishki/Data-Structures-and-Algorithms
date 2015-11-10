namespace _01.PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private IComparer<T> Comparer;
        private BinaryHeap<T> data;

        public PriorityQueue() : this(Comparer<T>.Default)
        {
            data = new BinaryHeap<T>(this.Comparer);
        }

        public PriorityQueue(IComparer<T> comp)
        {
            this.Comparer = comp;
        }

        public void Clear()
        {
            data.Clear();
        }

        public T Dequeue()
        {
            return this.data.RemoveRoot();
        }

        public void Enqueue(T item)
        {
            this.data.Insert(item);
        }

        public IEnumerator GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        public T Peek()
        {
            return this.data.Peek();
        }
    }
}
