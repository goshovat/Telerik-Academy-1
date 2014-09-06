namespace _05.HashedSet
{
    using System.Collections;
    using System.Collections.Generic;

    using _04.HashTable;

    /// <summary>
    /// Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> 
    /// to hold the elements. Implement all standard set operations like Add(T), Find(T), Remove(T), 
    /// Count, Clear(), union and intersect.
    /// </summary>
    /// <typeparam name="T">Generic value</typeparam>
    public class HashedSet<T> : IEnumerable
    {
        private HashTable<int, T> elements;

        public HashedSet()
        {
            this.elements = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T value)
        {
            this.elements.Add(value.GetHashCode(), value);
        }

        public bool Find(T value)
        {
            var isFound = false;

            if (this.elements.Find(value.GetHashCode()) != null)
            {
                isFound = true;
            }

            return isFound;
        }

        public void Remove(T value)
        {
            this.elements.Remove(value.GetHashCode());
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public HashedSet<T> Union(HashedSet<T> otherSet)
        {
            var unionSet = this;

            foreach (var item in otherSet.elements)
            {
                if (!unionSet.elements.Keys.Contains(item.Key))
                {
                    unionSet.Add(item.Value);
                }
            }

            return unionSet;
        }

        public HashedSet<T> Intersect(HashedSet<T> otherSet)
        {
            var unionSet = new HashedSet<T>();
            var currectSet = this;

            foreach (var item in otherSet.elements)
            {
                if (currectSet.elements.Keys.Contains(item.Key))
                {
                    unionSet.Add(item.Value);
                }
            }

            return unionSet;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element.Value;
            }
        }
    }
}
