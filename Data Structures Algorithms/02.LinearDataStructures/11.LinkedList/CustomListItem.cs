namespace _11.LinkedList
{
    using System;

    internal class CustomListItem<T>
        where T : IComparable
    {
        private T value;
        private CustomListItem<T> nextItem;

        public CustomListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public CustomListItem<T> Next
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
