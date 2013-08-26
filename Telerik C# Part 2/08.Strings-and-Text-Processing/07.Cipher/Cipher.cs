using System;
using System.Text;

/*
    Write a program that encodes and decodes a string using given encryption key (cipher). 
    The key consists of a sequence of characters. The encoding/decoding is done by performing XOR 
    (exclusive or) operation over the first letter of the string with the first of the key, 
    the second – with the second, etc. When the last key character is reached, the next is the first.
*/

class Cipher
{
    public static string Encoding(string text, string cipher)
    {
        StringBuilder encodingText = new StringBuilder();

        for (int i = 0, j = 0; i < text.Length; i++, j++)
        {
            if (j == cipher.Length)
            {
                j = 0;
            }

            encodingText.Append((char)(text[i] ^ cipher[j]));
        }

        return encodingText.ToString();
    }

    static void Main(string[] args)
    {
        Console.Title = "Cipher";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        Console.Write("Enter the encryption key (cipher): ");
        string cipher = Console.ReadLine();

        text = Encoding(text, cipher);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEncoded text: {0}", text);

        text = Encoding(text, cipher);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Decoded text: {0}", text);

        Console.WriteLine();
        Console.ResetColor();
    }
}