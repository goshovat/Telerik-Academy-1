using System;

/* 
    Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
    and out of the rectangle R(top=1, left=-1, width=6, height=2).
*/

class CheckPoint
{
    static void Main(string[] args)
    {
        Console.Write("Enter the coordinate x = ");
        double xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter the coordinate y = ");
        double yCoordinate = double.Parse(Console.ReadLine());
        double pointRadius = Math.Sqrt((xCoordinate - 1) * (xCoordinate - 1) + (yCoordinate - 1) * (yCoordinate - 1));
        bool isWithinCircle = pointRadius <= 3.0;
        // I could not decide which one is the correct rectangle so I made checks for both
        bool isWithinFirstRectangle = xCoordinate >= -1.0 && xCoordinate <= 5.0 && yCoordinate >= -1.0 && yCoordinate <= 1.0;
        bool isWithinSecondRectangle = xCoordinate >= 1.0 && xCoordinate <= 7.0 && yCoordinate >= -3.0 && yCoordinate <= -1.0;
        if (isWithinCircle)
        {
            Console.Write("The point ({0},{1}) is within the circle K((1,1),3)  ", xCoordinate, yCoordinate);
        }
        else
        {
            Console.Write("The point ({0},{1}) is out of the circle K((1,1),3) ", xCoordinate, yCoordinate);
        }
        // First rectangle R((-1,1),(5,-1)), where (-1,1) is the top left corner and (5,-1) is the bottom right corner
        if (isWithinFirstRectangle)
        {
            Console.Write("and is within the rectangle R((-1,1),(5,-1)) ");
        }
        else
        {
            Console.Write("and is out of the rectangle R((-1,1),(5,-1))  ");
        }
        // Second rectanle R((1,-1),(7,-3)), where (1,1) is the top left corner and (7,-3) is the bottom right corner
        if (isWithinSecondRectangle)
        {
            Console.WriteLine("and is within the rectangle R((1,-1),(7,-3)) ");
        }
        else
        {
            Console.WriteLine("and is out of the rectangle R((1,-1),(7,-3)) ");
        }
    }
}