namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T minElement = collection[i];
                int minElementPosition = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(minElement) < 0)
                    {
                        minElement = collection[j];
                        minElementPosition = j;
                    }
                }

                collection[minElementPosition] = collection[i];
                collection[i] = minElement;
            }
        }
    }
}
