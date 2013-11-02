namespace CallHistoryTest
{
    /*
        12.Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        - Create an instance of the GSM class.
        - Add few calls.
        - Display the information about the calls.
        - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        - Remove the longest call from the history and calculate the total price again.
        - Finally clear the call history and print it.
    */

    using System;
    using System.Linq;
    using MobilePhone;

    public class GSMCallHistoryTest
    {
        static void Main(string[] args)
        {
            GSM gsm = new GSM("HTC One X", "HTC", 799.00, "Vankata", 4.7, 16000000);
            gsm.AddCall(new Call(DateTime.Parse("12.09.2013 15:00:12"), "+359888333555", 122)); // Price for the call = 1.11
            gsm.AddCall(new Call(DateTime.Parse("20.9.2013 17:52:51"), "+359889121223", 54)); // Price for the call = 0.37
            gsm.AddCall(new Call(DateTime.Parse("25.09.2013 8:10:22"), "+359789444222", 180)); // Price for the call = 1.11

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(gsm.CallsInformation());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Total price of the calls = {0}", gsm.TotalPriceOfCalls(0.37)); // Total price = 2.59

            int maxDuration = -1;
            int indexMaxDuration = -1;

            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                if (gsm.CallHistory[i].Duration > maxDuration)
                {
                    maxDuration = gsm.CallHistory[i].Duration;
                    indexMaxDuration = i;
                }
            }

            gsm.DeleteCall(indexMaxDuration);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Total price of the calls = {0}", gsm.TotalPriceOfCalls(0.37)); // Total price = 1.48

            gsm.ClearHistory();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total price of the calls = {0}", gsm.TotalPriceOfCalls(0.37)); // Total price = 0

            Console.WriteLine();
        }

    }
}
