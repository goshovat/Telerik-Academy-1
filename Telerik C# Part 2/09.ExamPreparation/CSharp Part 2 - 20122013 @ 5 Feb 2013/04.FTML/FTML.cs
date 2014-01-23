using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _04.FTML
{
    class FTML
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] text = new string[lines];

            for (int index = 0; index < lines; index++)
            {
                text[index] = Console.ReadLine();
                text[index] = RemoveTags(text[index]);
            }

            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }

        private static string RemoveTags(string line)
        {
            StringBuilder changedLine = new StringBuilder(line);

            // del
            string[] delLine = changedLine.ToString().Split(new string[] { "<del>", "</del>" }, StringSplitOptions.None);
            changedLine = new StringBuilder();

            if (delLine.Length != 1)
            {
                for (int i = 0; i < delLine.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        changedLine.Append(delLine[i]);
                    }
                }
            }
            else
            {
                changedLine.Append(delLine[0]);
            }
            // ------------------Popravi-------------------------
            // toggle
            string[] toggleLine = changedLine.ToString().Split(new string[] { "<toggle>", "</toggle>" }, StringSplitOptions.None);

            changedLine = new StringBuilder();

            if (toggleLine.Length != 1)
            {
                for (int i = 0; i < toggleLine.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        char[] characters = toggleLine[i].ToCharArray();
                        for (int j = 0; j < toggleLine[i].Length; j++)
                        {
                            if (Char.IsLower(characters[j]))
                            {
                                changedLine.Append(Char.ToUpper(characters[j]));
                            }
                            else
                            {
                                changedLine.Append(Char.ToLower(characters[j]));
                            }
                        }
                    }
                    else
                    {
                        changedLine.Append(toggleLine[i]);
                    }
                }
            }
            else
            {
                changedLine.Append(toggleLine[0]);
            }

            // upper
            string[] upperLine = changedLine.ToString().Split(new string[] { "<upper>", "</upper>", "<UPPER>", "</UPPER>" }, StringSplitOptions.None);

            changedLine = new StringBuilder();

            if (upperLine.Length != 1)
            {
                for (int i = 0; i < upperLine.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        changedLine.Append(upperLine[i].ToUpper());
                    }
                    else
                    {
                        changedLine.Append(upperLine[i]);
                    }
                }
            }
            else
            {
                changedLine.Append(upperLine[0]);
            }

            // lower
            string[] lowerLine = changedLine.ToString().Split(new string[] { "<lower>", "</lower>", "<LOWER>", "</LOWER>" }, StringSplitOptions.None);

            changedLine = new StringBuilder();

            if (lowerLine.Length != 1)
            {
                for (int i = 0; i < lowerLine.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        changedLine.Append(lowerLine[i].ToLower());
                    }
                    else
                    {
                        changedLine.Append(lowerLine[i]);
                    }
                }
            }
            else
            {
                changedLine.Append(lowerLine[0]);
            }

            // ------------------Popravi-------------------------
            //rev
            string revLine = changedLine.ToString();

            int indexRev = revLine.LastIndexOf("<rev>");
            int tempIndex = revLine.LastIndexOf("<REV>");

            if (tempIndex > indexRev)
            {
                indexRev = tempIndex;
            }

            int indexRevClose = revLine.IndexOf("</", indexRev + 1);

            while (indexRev != -1)
            {
                changedLine = new StringBuilder();

                // DOBAVQME NA4ALOTO
                changedLine.Append(revLine.Substring(0, indexRev));
                
                //REVERSVAME SREDATA
                char[] characters = revLine.Substring(indexRev + 5, indexRevClose - indexRev - 5).ToCharArray();
                Array.Reverse(characters);
                changedLine.Append(new string(characters));
                
                //DOBAVQME KRAQ
                changedLine.Append(revLine.Substring(indexRevClose + 6));


                revLine = changedLine.ToString();

                indexRev = revLine.LastIndexOf("<rev>");
                tempIndex = revLine.LastIndexOf("<REV>");

                if (tempIndex > indexRev)
                {
                    indexRev = tempIndex;
                }

                indexRevClose = revLine.IndexOf("</", indexRev + 1);
            }

            return changedLine.ToString();
        }

    }
}
