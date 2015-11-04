namespace _4.HashTable
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IHashTable<K, T> : IEnumerable
    {
        T this[K key] { get; set; }

        ICollection<K> Keys { get; }

        void Add(K key, T value);

        T Find(K key);

        void Remove(K key);

        void Clear();
    }
}
