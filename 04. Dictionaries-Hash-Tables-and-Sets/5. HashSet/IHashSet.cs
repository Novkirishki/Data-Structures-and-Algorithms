namespace _5.HashSet
{
    using System.Collections;

    public interface IHashSet<T> : IEnumerable
    {
        void Add(T value);

        bool Find(T value);

        void Remove(T value);

        void Clear();
    }
}
