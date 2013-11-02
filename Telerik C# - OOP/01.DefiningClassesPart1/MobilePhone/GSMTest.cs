namespace MobilePhone
{
    /*
        7.Write a class GSMTest to test the GSM class:
        - Create an array of few instances of the GSM class.
        - Display the information about the GSMs in the array.
        - Display the information about the static property IPhone4S.
    */

    using System;
    using System.Linq;

    public class GSMTest
    {
        static void Main(string[] args)
        {
            GSM[] gsm = new GSM[4];

            gsm[0] = new GSM("LG Optimus L7", "LG");
            gsm[1] = new GSM("Samsung Galaxy S4", "Samsung", 900.00, "Pesho");
            gsm[2] = new GSM("HTC One X", "HTC", 799.00, "Vankata", 4.7, 16000000);
            gsm[3] = new GSM("Sony Xperia Z 1", "Sony", 1300, "Maco", "Non-removable Li-Ion 3000 mAh battery", 880, 15, BatteryType.LiIon);

            int index = 0;
            foreach (var item in gsm)
            {
                Console.ForegroundColor = ConsoleColor.Blue + index;
                Console.WriteLine(item);
                index++;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
