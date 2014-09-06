namespace _04.HashTable
{
    using System;

    public class HashTableDemo
    {
        public static void Main(string[] args)
        {
           var hashTable = new HashTable<string, int>();

            for (int i = 0; i < 20; i++)
            {
                hashTable.Add("pesho" + i, i);
            }

            var countString = "Count: {0}";

            Console.WriteLine(countString, hashTable.Count);

            var pattern = "Key: {0} -> Value: {1}";

            foreach (var item in hashTable)
            {
                Console.WriteLine(pattern, item.Key, item.Value);
            }
        }
    }
}
