namespace _13.Queue
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            var queue = new CustomLinkedQueue<DateTime>();

            queue.Enqueue(DateTime.Now);
            queue.Enqueue(new DateTime(2000, 12, 12));
            queue.Enqueue(new DateTime(1999, 1, 1));

            Console.WriteLine("Peaked element: {0}\n", queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine("Removed element: {0}", queue.Dequeue());
            }
        }
    }
}
