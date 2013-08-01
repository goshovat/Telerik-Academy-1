using System;

class ShipDamage
{
    static void Main(string[] args)
    {

        int shipX1 = int.Parse(Console.ReadLine());


        int shipY1 = int.Parse(Console.ReadLine());


        int shipX2 = int.Parse(Console.ReadLine());


        int shipY2 = int.Parse(Console.ReadLine());


        int h = int.Parse(Console.ReadLine());


        int catapultX1 = int.Parse(Console.ReadLine());


        int catapultY1 = int.Parse(Console.ReadLine());


        int catapultX2 = int.Parse(Console.ReadLine());


        int catapultY2 = int.Parse(Console.ReadLine());


        int catapultX3 = int.Parse(Console.ReadLine());


        int catapultY3 = int.Parse(Console.ReadLine());

        int damages = 0;
        int bombY;


        bombY = Bomb(h, catapultY1);
        damages = Damage(catapultX1, bombY, shipX1, shipY1, shipX2, shipY2);

        bombY = Bomb(h, catapultY2);
        damages += Damage(catapultX2, bombY, shipX1, shipY1, shipX2, shipY2);

        bombY = Bomb(h, catapultY3);
        damages += Damage(catapultX3, bombY, shipX1, shipY1, shipX2, shipY2);
        Console.WriteLine(damages + "%");
    }

    static int Damage(int projectileX, int projectileY, int shipX1, int shipY1, int shipX2, int shipY2)
    {
        int damage = 0;
        int width;
        int height;
        width = Math.Abs(shipX1 - shipX2);
        height = Math.Abs(shipY1 - shipY2);

        bool topLeft = projectileX == shipX1 && projectileY == shipY1;
        bool bottomLeft = projectileX == shipX1 && projectileY == shipY2;
        bool topRight = projectileX == shipX2 && projectileY == shipY1;
        bool bottomRight = projectileX == shipX2 && projectileY == shipY2;

        bool downSide = new bool();
        bool upside = new bool();
        bool leftSide = new bool();
        bool rightSide = new bool();

        bool inside = new bool();

        if (shipX1 > shipX2 && shipY1 > shipY2)
        {
            downSide = projectileY == shipY2 && (projectileX > shipX2 && projectileX < shipX1);
            upside = projectileY == shipY1 && (projectileX > shipX2 && projectileX < shipX1);
            leftSide = projectileX == shipX2 && (projectileY > shipY2 && projectileY < shipY1);
            rightSide = projectileX == shipX1 && (projectileY > shipY2 && projectileY < shipY1);
            inside = (projectileX > shipX2 && projectileX < shipX1) && (projectileY > shipY2 && projectileY < shipY1);
        }
        else if (shipX1 < shipX2 && shipY1 > shipY2)
        {
            downSide = projectileY == shipY2 && (projectileX > shipX1 && projectileX < shipX2);
            upside = projectileY == shipY1 && (projectileX > shipX1 && projectileX < shipX2);
            leftSide = projectileX == shipX1 && (projectileY > shipY2 && projectileY < shipY1);
            rightSide = projectileX == shipX2 && (projectileY > shipY2 && projectileY < shipY1);
            inside = (projectileX > shipX1 && projectileX < shipX2) && (projectileY > shipY2 && projectileY < shipY1);
        }
        else if (shipX1 < shipX2 && shipY1 < shipY2)
        {
            downSide = projectileY == shipY1 && (projectileX > shipX1 && projectileX < shipX2);
            upside = projectileY == shipY2 && (projectileX > shipX1 && projectileX < shipX2);
            leftSide = projectileX == shipX1 && (projectileY > shipY1 && projectileY < shipY2);
            rightSide = projectileX == shipX2 && (projectileY > shipY1 && projectileY < shipY2);
            inside = (projectileX > shipX1 && projectileX < shipX2) && (projectileY > shipY1 && projectileY < shipY2);
        }
        else
        {
            downSide = projectileY == shipY1 && (projectileX > shipX2 && projectileX < shipX1);
            upside = projectileY == shipY2 && (projectileX > shipX2 && projectileX < shipX1);
            leftSide = projectileX == shipX2 && (projectileY > shipY1 && projectileY < shipY2);
            rightSide = projectileX == shipX1 && (projectileY > shipY1 && projectileY < shipY2);
            inside = (projectileX > shipX2 && projectileX < shipX1) && (projectileY > shipY1 && projectileY < shipY2);
        }


        if (topLeft || topRight || bottomLeft || bottomRight)
        {
            damage = 25;
        }
        else if (downSide || upside || leftSide || rightSide)
        {
            damage = 50;
        }
        else if (inside)
        {
            damage = 100;
        }
        return damage;
    }

    static int Bomb(int h, int y)
    {
        int bomb = 2 * h - y;
        return bomb;
    }
}