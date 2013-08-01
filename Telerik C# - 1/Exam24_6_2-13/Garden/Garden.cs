using System;

class Garden
{
    static void Main(string[] args)
    {
        int tomatoAmount = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
       /* if (tomatoArea == 0 || tomatoAmount == 0)
        {
            tomatoAmount = 0;
            tomatoArea = 0;
        }*/

        int cucumberAmount = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
      /*  if (cucumberArea == 0)
        {
            cucumberAmount = 0;
        }*/

        int potatoAmount = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
       /* if (potatoArea == 0)
        {
            potatoAmount = 0;
        }*/

        int carrotAmount = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
      /*  if (carrotArea == 0)
        {
            carrotAmount = 0;
        }*/

        int cabbageAmount = int.Parse(Console.ReadLine());

        int cabbageArea = int.Parse(Console.ReadLine());
       /* if (cabbageArea == 0)
        {
            cabbageAmount = 0;
        }*/


        int beansAmount = int.Parse(Console.ReadLine());

        int area = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;


        decimal cost = tomatoAmount * 0.5m + cucumberAmount * 0.4m + potatoAmount * 0.25m + carrotAmount * 0.6m + cabbageAmount * 0.3m + beansAmount * 0.4m;

        Console.WriteLine("Total costs: {0:F2}", cost);

        int remainingArea = 250 - area;

        if (remainingArea > 0)
        {
            Console.WriteLine("Beans area: {0}", remainingArea);
        }
        else if (remainingArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");

        }
    }
}