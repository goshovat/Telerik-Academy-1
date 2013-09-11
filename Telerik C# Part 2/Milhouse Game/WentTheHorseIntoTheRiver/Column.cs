// -----------------------------------------------------------------------
// <copyright file="Columns.cs" company="Milhouse Game">
// TODO: Columns class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Columns class
    /// </summary>
    public class Column
    {
        private static int height;
        private static int width;
        private readonly string[] column = 
        {                           
                                        "\\__/",
                                        "|\\/|",
                                        "|/\\|",
                                        "|\\/|",
                                        "|/\\|"
        };

        private readonly int positionY;
        private int positionX;

        public Column(int positionX, int positionY)
        {
            height = this.column.Length;
            width = this.column[0].Length;
            this.positionX = positionX;
            this.positionY = positionY;
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

        public string[] GetColumn
        {
            get
            {
                return this.column;
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
            this.positionX--;
        }
    }
}