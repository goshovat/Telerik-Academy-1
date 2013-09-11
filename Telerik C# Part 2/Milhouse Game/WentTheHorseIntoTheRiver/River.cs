// -----------------------------------------------------------------------
// <copyright file="River.cs" company="Milhouse Game">
// TODO: River class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: River class
    /// </summary>
    public class River
    {
        private static int height;
        private static int width;
        private readonly string[] leftRiver;
        private readonly string[] rightRiver;
        private readonly int positionX;
        private readonly int positionY;
        private int number;

        public River(int riverHeight, int riverWidth, int positionX, int positionY)
        {
            this.leftRiver = new string[riverHeight];
            this.rightRiver = new string[riverHeight];
            StringBuilder makeLeftRiver;
            StringBuilder makeRightRiver;

            for (int row = 0; row < riverHeight; row++)
            {
                makeLeftRiver = new StringBuilder();
                makeRightRiver = new StringBuilder();

                for (int col = 0; col < riverWidth; col++)
                {
                    if (col % 2 == 0)
                    {
                        makeLeftRiver.Append(" ");
                        makeRightRiver.Append("~");
                    }
                    else
                    {
                        makeLeftRiver.Append("~");
                        makeRightRiver.Append(" ");
                    }
                }

                this.leftRiver[row] = makeLeftRiver.ToString();
                this.rightRiver[row] = makeRightRiver.ToString();

                row++;
                if (row < riverHeight)
                {
                    makeLeftRiver = new StringBuilder();
                    makeRightRiver = new StringBuilder();

                    for (int col = 0; col < riverWidth; col++)
                    {
                        if (col % 2 == 0)
                        {
                            makeLeftRiver.Append("~");
                            makeRightRiver.Append(" ");
                        }
                        else
                        {
                            makeLeftRiver.Append(" ");
                            makeRightRiver.Append("~");
                        }
                    }

                    this.leftRiver[row] = makeLeftRiver.ToString();
                    this.rightRiver[row] = makeRightRiver.ToString();
                }
            }

            this.positionX = positionX;
            this.positionY = positionY;
            height = riverHeight;
            width = riverWidth;
            this.number = 1;
        }

        public string[] GetRiver
        {
            get
            {
                if (this.number == 1)
                {
                    return this.leftRiver;
                }
                else
                {
                    return this.rightRiver;
                }
            }
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

        public int PositionX
        {
            get
            {
                return this.positionX;
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
            if (this.number == 1)
            {
                this.number = 2;
            }
            else
            {
                this.number = 1;
            }
        }
    }
}
