// -----------------------------------------------------------------------
// <copyright file="LevelElements.cs" company="Milhouse Game">
// TODO: LevelElements class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: LevelElements class
    /// </summary>
    public class LevelElements
    {
        private readonly int positionY;
        private readonly int height;
        private readonly int width;
        private string[] element;
        private int positionX;
        private int previousPositionX;

        public LevelElements(int height, int width, int positionX, int positionY, string[] element)
        {
            this.height = height;
            this.width = width;
            this.positionX = positionX;
            this.positionY = positionY;
            this.previousPositionX = positionX;
            this.element = element;
        }

        public string[] Element
        {
            get
            {
                return this.element;
            }

            set
            {
                this.element = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
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
    }
}