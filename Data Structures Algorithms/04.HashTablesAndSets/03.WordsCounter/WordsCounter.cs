namespace _03.WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Write a program that counts how many times each word from given text file 
    /// words.txt appears in it. The character casing differences should be ignored. 
    /// The result words should be ordered by their number of occurrences in the text. Example:
    /// This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
    /// is -> 2
    /// the -> 2
    /// this -> 3
    /// text -> 6
    /// </summary>
    public class WordsCounter
    {
        public static void Main(string[] args)
        {
            var filePath = "..\\..\\words.txt";

            var sortedOccurrences = FindWordsOccurrences(filePath);
            var pattern = "{0} -> {1} times";

            foreach (var occurrence in sortedOccurrences)
            {
                Console.WriteLine(pattern, occurrence.Key, occurrence.Value);
            }
        }

        private static IOrderedEnumerable<KeyValuePair<string, int>> FindWordsOccurrences(string path)
        {
            StreamReader reader = new StreamReader(path);
            var text = reader.ReadToEnd();

            var separaters = new string[] { ",", ".", "-", "–", "№", "!", "?", ":", "%", "(", ";", ")", " ", "\"", "|", "\\", "/", "\t", "\n", "\r" };

            text = text.ToLower();

            var allWords = text.Split(separaters, StringSplitOptions.RemoveEmptyEntries);

            var occurrences = new Dictionary<string, int>();

            foreach (var word in allWords)
            {
                if (!occurrences.ContainsKey(word))
                {
                    occurrences[word] = 0;
                }

                occurrences[word]++;
            }

            var sortedOccurrences = occurrences.OrderBy(o => o.Value).ThenBy(o => o.Key);

            return sortedOccurrences;
        }
    }
}
