using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Decode
{
    class Decode
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            int index = message.Length - 1;
            StringBuilder str = new StringBuilder();
            
            while (true)
            {
                if (char.IsDigit(message[index]))
                {
                    str.Insert(0, message[index]);
                }
                else
                {
                    break;
                }
                index--;
            }

            int cipherLength = int.Parse(str.ToString());
            message = message.Substring(0, message.Length - str.Length);

            message = Decodes(message);

            string cipher = message.Substring(message.Length - cipherLength, cipherLength);
            string encryptMessage = message.Substring(0, message.Length - cipherLength);

            encryptMessage = Encrypt(encryptMessage, cipher);


            for (int i = 0; i < encryptMessage.Length; i++)
            {
                if (encryptMessage[i] >= 65 && encryptMessage[i] < 90)
                {
                }
                else
                {
                    throw new IndexOutOfRangeException("ne sa glavni bukvi");
                }
            }

            Console.WriteLine(encryptMessage);
        }

        private static string Encrypt(string text, string cipher)
        {
            StringBuilder encodingText = new StringBuilder();

            if (text.Length >= cipher.Length)
            {
                for (int i = 0, j = 0; i < text.Length; i++, j++)
                {
                    if (j == cipher.Length)
                    {
                        j = 0;
                    }

                    char p = text[i];
                    char q = cipher[j];

                    p = (char)(((p - 65) ^ (q - 65)) + 65);

                    encodingText.Append(p);
                }
            }
            else
            {
                bool check = false;
                int i = 0;
                for (int j = 0; j < cipher.Length; i++, j++)
                {
                    if (i == text.Length)
                    {
                        i = 0;
                        text = encodingText.ToString();
                        encodingText = new StringBuilder();
                        check = true;
                    }
                    char p = text[i];
                    char q = cipher[j];

                    p = (char)(((p - 65) ^ (q - 65)) + 65);

                    encodingText.Append(p);
                }

                if (check)
                {
                    encodingText.Append(text.Substring(i));
                }
            }

            return encodingText.ToString();
        }


        private static string Decodes(string text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (char.IsDigit(text[i]) && char.IsLetter(text[i+ 1]))
                {
                    if (text[i] == 2)
                    {
                        continue;
                    }
                    text = text.Replace(text.Substring(i,2), new string(text[i+1], int.Parse(text[i].ToString())));
                    i++;
                }
                else if ((i + 2 <= text.Length) && (char.IsDigit(text[i]) && char.IsDigit(text[i + 1]) && char.IsLetter(text[i + 2])))
                {
                    text = text.Replace(text.Substring(i,3), new string(text[i+2], int.Parse(text.Substring(i, 2).ToString())));
                    i += 2;
                }
                else if ((i + 3 <= text.Length) && (char.IsDigit(text[i]) && char.IsDigit(text[i + 1]) && char.IsDigit(text[i + 2])  && char.IsLetter(text[i + 3])))
                {
                    text = text.Replace(text.Substring(i,4), new string(text[i+3], int.Parse(text.Substring(i, 3).ToString())));
                    i += 3;
                }
                else if ((i + 4 <= text.Length) && (char.IsDigit(text[i]) && char.IsDigit(text[i + 1]) && char.IsDigit(text[i + 2]) && char.IsDigit(text[i + 3])  && char.IsLetter(text[i + 4])))
                {
                    text = text.Replace(text.Substring(i,5), new string(text[i+4], int.Parse(text.Substring(i, 4).ToString())));
                    i += 4;
                }
                else if ((i + 4 <= text.Length) && (char.IsDigit(text[i]) && char.IsDigit(text[i + 1]) && char.IsDigit(text[i + 2]) && char.IsDigit(text[i + 3]) && char.IsDigit(text[i + 4])  && char.IsLetter(text[i + 5])))
                {
                    text = text.Replace(text.Substring(i,6), new string(text[i+5], int.Parse(text.Substring(i, 5).ToString())));
                    i += 5;
                }
            }

            return text;
        }
    }
}
