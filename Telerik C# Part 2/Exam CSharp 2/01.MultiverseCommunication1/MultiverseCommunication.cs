using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MultiverseCommunication1
{
    class MultiverseCommunication
    {
        //Change this
        private static string[] numbers = {
                                              "CHUA",
                                              "TEL",
                                              "OFT",
                                              "IVA",
                                              "EMY",
                                              "VNBSA",
                                              "POQ",
                                              "ERI",
                                              "CAD",
                                              "K-A",
                                              "IIA",
                                              "YLO",
                                              "PLA"
                                          };

        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            ulong decimalNumber = 0;

            int symbol = 5; //Change this
            bool gotItem = false;

            List<int> getNumbers = new List<int>();

            for (int i = 0; i < message.Length; i++)
            {
                if (symbol + i > message.Length)
                {
                    symbol = message.Length - i;
                }

                string word = message.Substring(i, symbol);
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (word == numbers[j])
                    {
                        getNumbers.Insert(0, j);
                        gotItem = true;
                    }
                }

                if (!gotItem)
                {
                    symbol--;
                    i--;
                }
                else
                {
                    i += symbol - 1;
                    symbol = 5; //Change this
                }
            }


            for (int i = 0; i < getNumbers.Count; i++)
            {
                decimalNumber += (ulong)getNumbers[i] * (ulong)(Math.Pow(13, i));
            }


            Console.WriteLine(decimalNumber);

            //for (int i = message.Length -1; i >= 0; i-=3)
            //{
            //    decimalNumber += GetIndex(message.Substring(i - 2, 3)) * (ulong)Math.Pow(13, grade);
            //    grade++;
            //}

        }

        //private static ulong GetIndex(string number)
        //{
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        if (numbers[i] == number)
        //        {
        //            return (ulong)i;
        //        }
        //    }
        //    return 0;
        //}
    }
}
