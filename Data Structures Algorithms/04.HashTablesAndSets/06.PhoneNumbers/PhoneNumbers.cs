namespace _06.PhoneNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PhoneNumbers
    {
        public static void Main(string[] args)
        {
            var phonesFile = "..\\..\\phones.txt";
            var phones = ReadPhoneNumbers(phonesFile);

            var commandsFile = "..\\..\\commands.txt";
            var commands = ReadCommands(commandsFile);

            ExecuteCommands(phones, commands);
        }

        private static Dictionary<List<string>, string> ReadPhoneNumbers(string path)
        {
            var reader = new StreamReader(path);

            var phones = new Dictionary<List<string>, string>();

            using (reader)
            {
                var line = reader.ReadLine();
                var partsSeparators = new string[] { "|" };
                var namesSeparators = new string[] { " " };

                while (line != null)
                {
                    var parts = line.Split(partsSeparators, StringSplitOptions.RemoveEmptyEntries);
                    var personNames = parts[0].Split(namesSeparators, StringSplitOptions.RemoveEmptyEntries);

                    var names = new List<string>();

                    foreach (var name in personNames)
                    {
                        names.Add(name);
                    }

                    names.Add(parts[1].Trim());

                    phones.Add(names, parts[2].Trim());

                    line = reader.ReadLine();
                }
            }

            return phones;
        }

        private static Dictionary<List<string>, string> Find(Dictionary<List<string>, string> phones, string name, string town = null)
        {
            var selectedPhones = new Dictionary<List<string>, string>();
            var isTownNull = town == null;

            foreach (var phone in phones)
            {
                if (isTownNull)
                {
                    town = phone.Key.Last();
                }

                for (int i = 0; i < phone.Key.Count - 1; i++)
                {
                    if (phone.Key[i].ToLower() == name.ToLower() && phone.Key.Last().ToLower() == town.ToLower())
                    {
                        selectedPhones.Add(phone.Key, phone.Value);
                        break;
                    }
                }
            }

            return selectedPhones;
        }

        private static List<string> ReadCommands(string path)
        {
            var reader = new StreamReader(path);
            var commands = new List<string>();

            using (reader)
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    commands.Add(line);

                    line = reader.ReadLine();
                }
            }

            return commands;
        }

        private static void ExecuteCommands(Dictionary<List<string>, string> phones, List<string> commands)
        {
            var separators = new string[] { "(", ")", ", ", ",", "find" };

            foreach (var command in commands)
            {
                var parts = command.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                dynamic foundPhones;

                if (parts.Length == 2)
                {
                    foundPhones = Find(phones, parts[0], parts[1]);
                }
                else
                {
                    foundPhones = Find(phones, parts[0]);
                }

                Console.WriteLine("Executing: {0}", command);
                PrintPhones(foundPhones);
                Console.WriteLine();
            }
        }

        private static void PrintPhones(Dictionary<List<string>, string> phones)
        {
            foreach (var phone in phones)
            {
                foreach (var names in phone.Key)
                {
                    Console.Write(names + " ");
                }

                Console.WriteLine(phone.Value);
            }
        }
    }
}
