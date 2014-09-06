namespace _04.HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Implement the data structure "hash table" in a class HashTable<K,T>. 
    /// Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) 
    /// with initial capacity of 16. When the hash table load runs over 75%, perform resizing 
    /// to 2 times larger capacity. Implement the following methods and properties: Add(key, value), 
    /// Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to 
    /// support iterating over its elements with foreach.
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="T">Value</typeparam>
    public class HashTable<K, T> : IEnumerable
    {
        private const double ResizePercent = 75;

        private LinkedList<KeyValuePair<K, T>>[] elements;
        private IList<K> keys;

        private int capacity = 16;
        private int count = 0;

        public HashTable()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[this.capacity];
            this.keys = new List<K>();
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public IList<K> Keys
        {
            get
            {
                return this.keys;
            }

            private set
            {
                this.keys = value;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                var index = this.GetHashIndex(key.GetHashCode());

                if (this.elements[index] == null)
                {
                    throw new ArgumentException("There is no element with this key");
                }
                else
                {
                    var isFound = false;
                    var next = this.elements[index].First;

                    while (next != null)
                    {
                        if (next.Value.Key.Equals(key))
                        {
                            LinkedListNode<KeyValuePair<K, T>> node =
                                new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value));
                            this.elements[index].AddAfter(next, node);
                            this.elements[index].Remove(next);
                            isFound = true;
                            break;
                        }

                        next = next.Next;
                    }

                    if (!isFound)
                    {
                        throw new ArgumentException("There is no element with this key");
                    }
                }
            }
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void Add(K key, T value)
        {
            if (this.MustResize())
            {
                this.Resize();
            }

            int index = this.GetHashIndex(key.GetHashCode());

            if (this.elements[index] == null)
            {
                this.elements[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var next = this.elements[index].First;

            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    throw new ArgumentException("There is such key already");
                }

                next = next.Next;
            }

            this.elements[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.Count += 1;
            this.Keys.Add(key);
        }

        public void Remove(K key)
        {
            int index = Math.Abs(key.GetHashCode() % this.elements.Length);

            if (this.elements[index] == null)
            {
                throw new ArgumentException("There is no element with this key");
            }
            else
            {
                bool isFind = false;
                var next = this.elements[index].First;

                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        this.elements[index].Remove(next);
                        isFind = true;
                        this.count -= 1;
                    }

                    next = next.Next;
                }

                if (this.elements[index].First == null)
                {
                    this.capacity -= 1;
                    this.keys.Remove(key);
                }

                if (isFind == false)
                {
                    throw new ArgumentException("There is no element with this key");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i] != null)
                {
                    var next = this.elements[i].First;

                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        public T Find(K key)
        {
            int index = this.GetHashIndex(key.GetHashCode());

            if (this.elements[index] == null)
            {
                throw new ArgumentException("There is no element with this key");
            }
            else
            {
                var next = this.elements[index].First;

                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return next.Value.Value;
                    }

                    next = next.Next;
                }

                throw new ArgumentException("There is no element with this key");
            }
        }

        private int GetHashIndex(int elementHash)
        {
            return Math.Abs(elementHash % this.elements.Length);
        }

        private bool MustResize()
        {
            var filledPercent = (this.count / (double)this.capacity) * 100;
            var mustResize = false;

            if (filledPercent > ResizePercent)
            {
                mustResize = true;
            }

            return mustResize;
        }

        private void Resize()
        {
            this.capacity *= 2;
            var newEleemnts = new LinkedList<KeyValuePair<K, T>>[this.capacity];

            foreach (var key in keys)
            {
                int oldIndex = Math.Abs(key.GetHashCode() % this.elements.Length);
                int newIndex = Math.Abs(key.GetHashCode() % newEleemnts.Length);
                newEleemnts[newIndex] = this.elements[oldIndex];
            }

            this.elements = newEleemnts;
        }
    }
}
