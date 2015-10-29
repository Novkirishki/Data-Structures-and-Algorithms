namespace _12.Stack
{
    public class Stack<T>
    {
        private const int InitialArraySize = 4;
        private const int IncrementialValue = 2;

        private T[] array;
        private int numberOfElements;

        public Stack()
        {
            this.Array = new T[InitialArraySize];
            numberOfElements = 0;
        }

        private T[] Array
        {
            get
            {
                return array;
            }

            set
            {
                array = value;
            }
        }

        public void Push(T value)
        {
            if (numberOfElements == this.Array.Length)
            {
                var newArray = new T[numberOfElements * IncrementialValue];

                for (int i = 0; i < numberOfElements; i++)
                {
                    newArray[i] = this.Array[i];
                }

                this.Array = newArray;
            }

            this.Array[numberOfElements] = value;
            ++numberOfElements;
        }

        public T Pop()
        {
            --numberOfElements;
            return this.Array[numberOfElements];
        }

        public T Peek()
        {
            return this.Array[numberOfElements - 1];
        }

    }
}
