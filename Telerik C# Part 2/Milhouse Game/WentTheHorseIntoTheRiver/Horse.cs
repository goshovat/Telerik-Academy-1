// -----------------------------------------------------------------------
// <copyright file="Horse.cs" company="Milhouse Game">
// TODO: Horse class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;

    /// <summary>
    /// TODO: Horse class
    /// </summary>
    public class Horse
    {
        private readonly string[,] horse = 
        {
                                    { "    ,,, ",
                                      "  __//*)",
                                      "~(__)   ",
                                      "//  \\\\  "
                                    },
                                    { "    ,,, ",
                                      "  __//*)",
                                      "~(__)   ",
                                       "// ||   "
                                    },
                                    { "    ,,, ",
                                      "  __//*)",
                                      "~(__)   ",
                                      " || \\\\  "
                                    },
                                    { "\\\\__//  ",
                                      "~(__)   ",
                                      "    \\\\x)",
                                      "    *** "
                                    }
        };

        private readonly int height;
        private int number;
        private int positionX;
        private int positionY;
        private int width;
        private int priviousPositionY;

        public Horse(int positionX, int positionY)
        {
            this.number = 0;
            this.height = this.horse.GetLength(1);
            this.width = this.horse[this.number, 0].Length;
            this.positionX = positionX;
            this.positionY = positionY;
            this.priviousPositionY = positionY;
        }

        public string[] GetHorse
        {
            get
            {
                string[] currentHorse = new string[this.height];
                for (int i = 0; i < this.height; i++)
                {
                    currentHorse[i] = this.horse[this.number, i];
                }

                this.width = currentHorse[0].Length;

                return currentHorse;
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

        public int PreviousPositionY
        {
            get
            {
                return this.priviousPositionY;
            }

            set
            {
                this.priviousPositionY = this.positionY;
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

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        public void MoveUp(int areaPositionY)
        {
            if (this.positionY > areaPositionY)
            {
                this.priviousPositionY = this.positionY;
                this.positionY--;
            }
        }

        public void MoveDown(int areaPositionY, int areaHeight)
        {
            if (this.positionY < areaPositionY + areaHeight - 4)
            {
                this.priviousPositionY = this.positionY;
                this.positionY++;
            }
        }
    }
}