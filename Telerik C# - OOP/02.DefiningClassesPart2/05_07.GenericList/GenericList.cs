namespace _05_07.GenericList
{
    /*
        5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
        Keep the elements of the list in an array with fixed capacity which is given as parameter in the 
        class constructor. Implement methods for adding element, accessing element by index, removing 
        element by index, inserting element at given position, clearing the list, finding element by its 
        value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
        
        6.Implement auto-grow functionality: when the internal array is full, create a new array of double 
        size and move all elements to it.
        
        7.Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  
        GenericList<T>. You may need to add a generic constraints for the type T.
    */

    using System;
    using System.Text;

    public class GenericList<T>
        where T : IComparable
    {
        // Fields
        const int DefaultCapacity = 4;
        private T[] elements;
        private int count = 0;
        private int capacity;

        // Constructors
        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
            this.capacity = capacity;
        }

        public GenericList()
            : this(DefaultCapacity)
        {
        }

        // Properties
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                T result = this.elements[index];
                return result;
            }
        }

        // Methods
        public void Add(T element)
        {
            if (this.count > this.elements.Length)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "The list capacity of {0} was exceeded.", this.elements.Length));
            }

            this.IsFull();
            this.elements[count] = element;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
            }
            else
            {
                for (int position = index; position < this.count - 1; position++)
                {
                    this.elements[position] = this.elements[position + 1];
                }

                this.count--;
            }
        }

        public void InsertAt(int index, T element)
        {
            if (index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
            }
            else
            {
                this.IsFull();

                if (index == this.count)
                {
                    this.Add(element);
                }
                else
                {
                    for (int position = this.count - 1; position >= index; position--)
                    {
                        this.elements[position + 1] = this.elements[position];
                    }

                    this.elements[index] = element;
                    this.count++;
                }
            }
        }

        // Return the index of first occurrence of the element or -1 if it was not found
        public int Find(T element, int startIndex = 0)
        {
            for (int index = startIndex; index < this.count; index++)
            {
                if (element.Equals(this.elements[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        public void Clear()
        {
            this.count = 0;
        }

        // Check if the array is full and allocate double memory for the new array
        private void IsFull()
        {
            if (this.count == this.elements.Length)
            {
                T[] doubleLengthArray = new T[count * 2];

                for (int index = 0; index < this.count; index++)
                {
                    doubleLengthArray[index] = this.elements[index];
                }

                this.elements = doubleLengthArray;
                this.capacity = doubleLengthArray.Length;
            }
        }

        public override string ToString()
        {
            StringBuilder array = new StringBuilder();

            array.Append("List elements = { ");
            array.Append(this.elements[0]);

            for (int index = 1; index < this.count; index++)
            {
                array.Append(string.Format(", {0}", this.elements[index]));
            }

            array.Append(" }");

            return array.ToString();
        }

        public T Min()
        {
            if (count == 0)
            {
                throw new NullReferenceException("The list doesn't have any elements!!!");
            }

            dynamic minValue = this.elements[0];

            for (int index = 1; index < this.count; index++)
            {
                if (this.elements[index] < minValue)
                {
                    minValue = this.elements[index];
                }
            }

            return minValue;
        }

        public T Max()
        {
            if (count == 0)
            {
                throw new NullReferenceException("The list doesn't have any elements!!!");
            }

            dynamic maxValue = this.elements[0];

            for (int index = 1; index < this.count; index++)
            {
                if (this.elements[index] > maxValue)
                {
                    maxValue = this.elements[index];
                }
            }
            return maxValue;
        }
    }
}