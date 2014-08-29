namespace _12.Stack
{
    using System;
    using System.Text;

    public class CustomStack<T>
    {
        private const int InitialSize = 4;
        private T[] array;
        private int pointer;

        public CustomStack()
            : this(InitialSize)
        {
        }

        public CustomStack(int initialSize)
        {
            this.array = new T[initialSize];
            this.pointer = 0;
        }

        public int Count
        {
            get
            {
                return this.pointer;
            }
        }

        public void Push(T element)
        {
            if (this.pointer == this.array.Length)
            {
                this.AutoGrow();
            }

            this.array[this.pointer] = element;
            this.pointer++;
        }

        public T Peek()
        {
            if (this.pointer == 0)
            {
                throw new ArgumentException("The stack is empty!");
            }

            T objectToReturn = this.array[this.pointer - 1];

            return objectToReturn;
        }

        public T Pop()
        {
            var element = this.Peek();
            this.pointer--;
         
            return element;
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                builder.AppendFormat("{0} -> ", array[i]);
            }

            return builder.ToString();
        }

        private void AutoGrow()
        {
            T[] newArray = new T[2 * this.array.Length];
            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}