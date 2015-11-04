// Implement the data structure hash table in a class HashTable<K, T>. 
// Keep the data in array of lists of key-value pairs(LinkedList<KeyValuePair<K, T>>[]) 
// with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 
// 2 times larger capacity.Implement the following methods and properties:
//Add(key, value)
//Find(key)->value
//Remove(key)
//Count
//Clear()
//this[]
//Keys
//Try to make the hash table to support iterating over its elements with foreach.

namespace _4.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IHashTable<K, T> where K : IComparable
    {
        private const int InitialItemsCount = 16;
        private const int IncrementialValue = 2;

        private LinkedList<KeyValuePair<K, T>>[] table;

        public HashTable()
        {
            this.table = new LinkedList<KeyValuePair<K, T>>[InitialItemsCount];
            this.Keys = new HashSet<K>();
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.table.Length; }
        }

        public ICollection<K> Keys { get; private set; }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                if (this.Keys.Contains(key))
                {
                    this.Remove(key);
                }

                this.Add(key, value);
            }
        }

        public void Add(K key, T value)
        {
            if (this.Keys.Contains(key))
            {
                throw new InvalidOperationException("Key cannot be added twice");
            }

            if (this.Count + 1 > 0.75 * table.Length)
            {
                this.Resize();
            }

            var placeValue = this.GetCode(key);

            if (table[placeValue] == null)
            {
                table[placeValue] = new LinkedList<KeyValuePair<K, T>>();
            }

            table[placeValue].AddLast(new KeyValuePair<K, T>(key, value));
            this.Keys.Add(key);
            ++this.Count;
        }

        public void Clear()
        {
            foreach (var list in table)
            {
                if (list != null)
                {
                    list.Clear();
                }
            }

            this.Keys.Clear();
            this.Count = 0;
        }

        public T Find(K key)
        {
            if (!this.Keys.Contains(key))
            {
                throw new KeyNotFoundException("Element with such key does not exist");
            }

            var code = this.GetCode(key);
            var pair = this.table[code].Where(p => p.Key.CompareTo(key) == 0).First();

            return pair.Value;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var list in this.table)
            {
                if (list == null)
                {
                    continue;
                }

                foreach (var pair in list)
                {
                    yield return pair;
                }
            }
        }

        public void Remove(K key)
        {
            var code = this.GetCode(key);
            var pair = this.table[code].Where(p => p.Key.CompareTo(key) == 0).First();
            this.table[code].Remove(pair);

            this.Keys.Remove(key);
            --this.Count;
        }

        private void Resize()
        {
            var newTable = new LinkedList<KeyValuePair<K, T>>[this.table.Length * IncrementialValue];

            foreach (KeyValuePair<K, T> pair in this)
            {
                var placeValue = this.GetCode(pair.Key);

                if (newTable[placeValue] == null)
                {
                    newTable[placeValue] = new LinkedList<KeyValuePair<K, T>>();
                }

                newTable[placeValue].AddLast(new KeyValuePair<K, T>(pair.Key, pair.Value));
            }

            this.table = newTable;
        }

        private int GetCode(K key)
        {
            return Math.Abs(key.GetHashCode()) % table.Length;
        }
    }
}
