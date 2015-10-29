namespace _13.Queue
{
    using System.Collections.Generic;

    public class Queue<T>
    {
        private List<T> values;

        public Queue()
        {
            this.Values = new List<T>();
        }

        private List<T> Values
        {
            get
            {
                return values;
            }

            set
            {
                values = value;
            }
        }

        public void Enqueue(T value)
        {
            this.Values.Add(value);
        }

        public T Dequeue()
        {
            var firstValue = this.Values[0];
            this.Values.RemoveAt(0);
            return firstValue;
        }

        public T Peek()
        {
            return this.Values[0];
        }
    }
}
