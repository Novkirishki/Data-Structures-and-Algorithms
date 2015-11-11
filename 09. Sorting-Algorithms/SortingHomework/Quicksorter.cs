namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int start, int end)
        {
            if (start <= end)
            {
                T pivot = collection[start];
                var positionOfLastBigger = end;

                for (int i = end; i >= start; i--)
                {
                    if (collection[i].CompareTo(pivot) > 0)
                    {
                        this.Swap(positionOfLastBigger, i, collection);
                        --positionOfLastBigger;
                    }
                }

                this.Swap(positionOfLastBigger, start, collection);

                this.Sort(collection, start, positionOfLastBigger - 1);
                this.Sort(collection, positionOfLastBigger + 1, end);
            }
        }

        private void Swap(int start, int end, IList<T> collection)
        {
            var buff = collection[start];
            collection[start] = collection[end];
            collection[end] = buff;
        }
    }
}
