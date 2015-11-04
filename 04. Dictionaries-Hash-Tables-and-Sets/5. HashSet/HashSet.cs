namespace _5.HashSet
{
    using System.Collections;
    using _4.HashTable;
    using System.Collections.Generic;

    public class HashSet<T> : IHashSet<T>
    {
        private HashTable<int, T> table;

        public HashSet()
        {
            this.table = new HashTable<int, T>();
        }

        public int Count { get { return table.Count; } }

        public void Add(T value)
        {
            var code = value.GetHashCode();
            table.Add(code, value);
        }

        public void Clear()
        {
            table.Clear();
        }

        public bool Find(T value)
        {
            return this.table.Keys.Contains(value.GetHashCode());
        }

        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<int, T> pair in this.table)
            {
                yield return pair.Value;
            }
        }

        public void Remove(T value)
        {
            this.table.Remove(value.GetHashCode());
        }

        public HashSet<T> UnionWith(HashSet<T> other)
        {
            var result = new HashSet<T>();

            foreach (T item in this)
            {
                result.Add(item);
            }

            foreach (T item in other)
            {
                if (!result.Find(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public HashSet<T> IntersectWith(HashSet<T> other)
        {
            var result = new HashSet<T>();

            foreach (T item in this)
            {
                foreach (T item2 in other)
                {
                    if (item.GetHashCode() == item2.GetHashCode())
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
