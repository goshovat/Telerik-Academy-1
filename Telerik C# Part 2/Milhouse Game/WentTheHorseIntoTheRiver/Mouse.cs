// -----------------------------------------------------------------------
// <copyright file="Mouse.cs" company="Milhouse Game">
// TODO: Mouse class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Mouse class
    /// </summary>
    public class Mouse
    {
        private static int height;
        private static int width;
        private readonly string[] mouse = { ",, ", "<>~", "\'\' " };
        private int positionX;
        private int positionY;
        private int previousPositionX;

        public Mouse(int positionX, int positionY)
        {
            height = this.mouse.Length;
            width = this.mouse[0].Length;
            this.positionX = positionX;
            this.positionY = positionY;
            this.previousPositionX = positionX;
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

            set
            {
                this.positionY = value;
            }
        }

        public int PreviousPositionX
        {
            get
            {
                return this.previousPositionX;
            }

            set
            {
                this.previousPositionX = value;
            }
        }

        public string[] GetMouse
        {
            get
            {
                return this.mouse;
            }
        }

        public static int Height()
        {
            return height;
        }

        public static int Width()
        {
            return width;
        }
    }
}
