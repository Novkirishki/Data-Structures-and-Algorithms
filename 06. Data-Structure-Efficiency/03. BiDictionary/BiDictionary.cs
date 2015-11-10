namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> firstKeyDict;
        private MultiDictionary<K2, T> secondKeyDict;

        public BiDictionary()
        {
            this.firstKeyDict = new MultiDictionary<K1, T>(true);
            this.secondKeyDict = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (this.firstKeyDict.Contains(key1, value) && this.secondKeyDict.Contains(key2, value))
            {
                throw new ArgumentException("An element with these keys exists in dictionary");
            }

            firstKeyDict.Add(key1, value);
            secondKeyDict.Add(key2, value);
        }

        public void Remove(K1 key1, K2 key2, T value)
        {
            firstKeyDict.Remove(key1, value);
            secondKeyDict.Remove(key2, value);
        }

        public void Clear()
        {
            firstKeyDict.Clear();
            secondKeyDict.Clear();
        }

        public bool Contains(K1 key1, K2 key2, T value)
        {
            if (this.firstKeyDict.Contains(key1, value) && this.secondKeyDict.Contains(key2, value))
            {
                return true;
            }

            return false;
        }

        public ICollection<T> Search(K1 key)
        {
            return firstKeyDict[key];
        }

        public ICollection<T> Search(K2 key)
        {
            return secondKeyDict[key];
        }

        public ICollection<T> Search(K1 key1, K2 key2)
        {
            var firstDictResults = firstKeyDict[key1];
            var secondDictResults = secondKeyDict[key2];
            var result = new HashSet<T>();

            foreach (var item1 in firstDictResults)
            {
                foreach (var item2 in secondDictResults)
                {
                    if (item1.Equals(item2))
                    {
                        result.Add(item2);
                    }
                }
            }

            return result;
        }
    }
}
