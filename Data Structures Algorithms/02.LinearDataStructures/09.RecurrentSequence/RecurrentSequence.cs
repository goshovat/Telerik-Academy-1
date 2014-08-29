namespace _09.RecurrentSequence
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RecurrentSequence
    {
        public static void Main(string[] args)
        {
            FindFirstNElements(2, 50);
        }

        private static void FindFirstNElements(int startNumber, int maxMembers)
        {
            var queue = new Queue<int>();
            var membersCounter = 1;
            var index = 0;

            queue.Enqueue(startNumber);

            var builder = new StringBuilder();

            while (membersCounter < maxMembers)
            {
                var memeber = queue.Dequeue();

                index++;
                builder.AppendFormat("Memeber[{0}] = {1}\n", index, memeber);

                queue.Enqueue(memeber + 1);
                queue.Enqueue(2 * memeber + 1);
                queue.Enqueue(memeber + 2);
                membersCounter += 3;
            }

            while (index < maxMembers)
            {
                var memeber = queue.Dequeue();
                index++;
                builder.AppendFormat("Memeber[{0}] = {1}\n", index, memeber);
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
