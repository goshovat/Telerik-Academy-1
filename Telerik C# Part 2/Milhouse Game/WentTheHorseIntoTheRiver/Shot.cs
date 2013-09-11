// -----------------------------------------------------------------------
// <copyright file="Shot.cs" company="Milhouse Game">
// TODO: Shot class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Shot class
    /// </summary>
    public class Shot
    {
        private readonly char shot;
        private int positionX;
        private int positionY;
        private int previousPositionX;

        public Shot(int positionX, int positionY)
        {
            this.shot = 'o';
            this.positionX = positionX;
            this.positionY = positionY;
            this.previousPositionX = positionX;
        }

        public char GetShot
        {
            get
            {
                return this.shot;
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
    }
}
