// -----------------------------------------------------------------------
// <copyright file="Bridge.cs" company="Milhouse Game">
// TODO: Bridge class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Bridge class
    /// </summary>
    public class Bridge
    {
        private static readonly int height = 3;
        private static int width;
        private readonly string[] upWall;
        private readonly string[] downWall;
        private readonly int upWallPositionX;
        private readonly int upWallPositionY;
        private readonly int downWallPositionX;
        private readonly int downWallPositionY;

        public Bridge(int bridgeWidth, int positionX, int upWallPositionY, int downWallPositionY)
        {
            this.upWall = new string[height];
            this.downWall = new string[height];

            for (int row = 0; row < height; row++)
            {
                if (row == 0 || row == height - 1)
                {
                    this.upWall[row] = new string('-', bridgeWidth);
                    this.downWall[row] = new string('-', bridgeWidth);
                }
                else
                {
                    this.upWall[row] = new string('/', bridgeWidth);
                    this.downWall[row] = new string('/', bridgeWidth);
                }
            }

            this.upWallPositionX = positionX;
            this.upWallPositionY = upWallPositionY;
            this.downWallPositionX = positionX;
            this.downWallPositionY = downWallPositionY;

            width = bridgeWidth;
        }

        public static int Height
        {
            get
            {
                return height;
            }
        }

        public static int Width
        {
            get
            {
                return width;
            }
        }

        public string[] UpWall2
        {
            get
            {
                return this.upWall;
            }
        }

        public string[] UpWall1
        {
            get
            {
                return this.upWall;
            }
        }

        public string[] UpWall
        {
            get
            {
                return this.upWall;
            }
        }

        public string[] DownWall
        {
            get
            {
                return this.downWall;
            }
        }

        public int UpWallPositionX
        {
            get
            {
                return this.upWallPositionX;
            }
        }

        public int UpWallPositionY
        {
            get
            {
                return this.upWallPositionY;
            }
        }

        public int DownWallPositionX
        {
            get
            {
                return this.downWallPositionX;
            }
        }

        public int DownWallPositionY
        {
            get
            {
                return this.downWallPositionY;
            }
        }
    }
}
