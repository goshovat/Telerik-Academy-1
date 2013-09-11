// -----------------------------------------------------------------------
// <copyright file="Clouds.cs" company="Milhouse Game">
// TODO: Clouds class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO:  Clouds class
    /// </summary>
    public class Clouds
    {
        private static int height;
        private static int width;
        private readonly string[] cloud = 
        {                          
                                   "    ___   __     ________           __________       ________          ___   __     ________         __________     ",
                                   "   /   \\_/  \\   /        \\         /          \\     /        \\        /   \\_/  \\   /        \\       /          \\    ",
                                   "  (          ) (   __     )       (            )    )    __  (       (          ) (   __     )      )          (    ",
                                   "   \\________/   \\_/  \\___/         \\__________/     \\___/  \\_/        \\________/   \\_/  \\___/       \\__________/    ",
        };
        
        private readonly int positionY;
        private int positionX;
        private int flyingCloud;

        public Clouds(int positionX, int positionY)
        {
            height = this.cloud.Length;
            width = this.cloud[0].Length;
            this.positionX = positionX;
            this.positionY = positionY;
            this.flyingCloud = 0;
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

        public string[] GetCloud
        {
            get
            {
                return this.cloud;
            }
        }

        public int PositionX
        {
            get
            {
                return this.positionX;
            }

            set
            {
                this.positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }
        }

        public void Move()
        {
            if (this.flyingCloud >= 0 && this.flyingCloud < 3)
            {
                this.positionX++;
                this.flyingCloud++;
            }
            else if (this.flyingCloud >= 3 && this.flyingCloud < 6)
            {
                this.flyingCloud++;
            }
            else if (this.flyingCloud >= 6 && this.flyingCloud < 9)
            {
                this.positionX--;
                this.flyingCloud++;
            }
            else if (this.flyingCloud >= 9 && this.flyingCloud < 12)
            {
                this.flyingCloud++;
            }
            else
            {
                this.flyingCloud = 0;
            }
        }
    }
}