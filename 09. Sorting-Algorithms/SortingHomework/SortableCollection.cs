namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var value in items)
            {
                if (item.CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new Quicksorter<T>());
            var start = 0;
            var end = this.items.Count - 1;
            while (start <= end)
            {
                var middle = (end + start) / 2;
                if (this.items[middle].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.items[middle].CompareTo(item) < 0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return false;
        }

        // Fisher–Yates shuffle - complexity O(n)
        public void Shuffle()
        {
            var random = new Random();
            for (int i = 0; i < this.items.Count - 2; i++)
            {
                var j = random.Next(i, this.items.Count);
                var buffer = this.items[i];
                this.items[i] = this.items[j];
                this.items[j] = buffer;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
