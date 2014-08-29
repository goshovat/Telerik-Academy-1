namespace _11.LinkedList
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var linkedList = new CustomLinkedList<int>();

            linkedList.AddItem(1);
            linkedList.AddFirst(2);
            linkedList.AddItem(3);
            linkedList.AddItem(4);
            Console.WriteLine(linkedList);

            linkedList.RemoveItem(3);
            Console.WriteLine(linkedList);

            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);
        }
    }
}
