namespace _13.Queue
{
    using System;
    using System.Collections.Generic;

    public class CustomLinkedQueue<T>
    {
        private readonly LinkedList<T> list;

        public CustomLinkedQueue()
        {
            this.list = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.list.AddLast(item);
        }

        public T Peek()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }

            return this.list.First.Value;
        }

        public T Dequeue()
        {
            T removedItem = this.Peek();
            this.list.RemoveFirst();

            return removedItem;
        }
    }
}
