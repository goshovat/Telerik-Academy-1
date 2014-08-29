namespace _11.LinkedList
{
    using System;
    using System.Linq;
    using System.Text;

    public class CustomLinkedList<T>
        where T : IComparable
    {
        private CustomListItem<T> firstElement;

        public CustomLinkedList()
        {
            this.firstElement = null;
        }

        public T FirstElement
        {
            get
            {
                return this.firstElement.Value;
            }
        }

        public void AddItem(T element)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new CustomListItem<T>(element);
            }
            else
            {
                var currentElement = this.firstElement;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }
                currentElement.Next = new CustomListItem<T>(element);
            }
        }

        public void RemoveItem(T element)
        {
            if (this.firstElement == null)
            {
                return;
            }

            var currentItem = this.firstElement;

            if (currentItem.Value.CompareTo(element) == 0)
            {
                this.firstElement = currentItem.Next;
                return;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.CompareTo(element) == 0)
                {
                    currentItem.Next = currentItem.Next.Next;
                    return;
                }

                currentItem = currentItem.Next;
            }
        }

        public void AddFirst(T element)
        {
            var newNode = new CustomListItem<T>(element);
            newNode.Next = this.firstElement;
            this.firstElement = newNode;
        }

        public void RemoveFirst()
        {
            this.firstElement = this.firstElement.Next;
        }

        public override string ToString()
        {
            if (this.firstElement == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            var currItem = this.firstElement;
            builder.Append(currItem.Value);

            while (currItem.Next != null)
            {
                builder.Append(" -> ");
                builder.Append(currItem.Next);
                currItem = currItem.Next;
            }

            return builder.ToString();
        }
    }
}
