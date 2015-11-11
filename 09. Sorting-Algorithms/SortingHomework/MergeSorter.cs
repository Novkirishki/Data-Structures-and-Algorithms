namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                var middle = (start + end) / 2;
                MergeSort(collection, start, middle);
                MergeSort(collection, middle + 1, end);

                // merging
                var currentPositon = start;
                var secondCollectionPosition = middle + 1;
                while (currentPositon <= middle )
                {
                    if (collection[currentPositon].CompareTo(collection[secondCollectionPosition]) > 0)
                    {
                        Swap(currentPositon, secondCollectionPosition, collection);

                        // keep second part sorted
                        while (secondCollectionPosition < end && collection[secondCollectionPosition].CompareTo(collection[secondCollectionPosition + 1]) > 0)
                        {
                            Swap(secondCollectionPosition, secondCollectionPosition + 1, collection);
                            ++secondCollectionPosition;
                        }

                        secondCollectionPosition = middle + 1;
                    }
                    ++currentPositon;
                }

                while (currentPositon < end && collection[currentPositon].CompareTo(collection[currentPositon + 1]) > 0)
                {
                    Swap(currentPositon, currentPositon + 1, collection);
                    ++currentPositon;
                }
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
