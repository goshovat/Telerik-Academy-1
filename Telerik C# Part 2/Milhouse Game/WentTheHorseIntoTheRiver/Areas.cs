// -----------------------------------------------------------------------
// <copyright file="Area.cs" company="Milhouse Game">
// TODO: Area class
// </copyright>
// -----------------------------------------------------------------------

namespace WentTheHorseIntoTheRiver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Area class
    /// </summary>
    public class Areas
    {
        private static readonly string[] names = { "Beginning", "The easy one", "Horse destruction", "The nesty one", "The Realy nesty one" };
        private readonly string[,] levels = 
        { 
            {
            "         []                                                        []                                                                  []                                                                                                                   []   ",
            "         []                                                        []                                                                  []                                  []                                                                               []   ",
            "         []                                                        []                                                                  []                                  []                                                                               []   ",
            "                                    []                             []                                                                  []                                  []                                                                               []   ",
            "                                    []                             []                                                                                                      []                                                                               []   ",
            "                                    []                             []                                                                                                      []                                          []                                   []   ",
            "                                    []                             []                               []                                                                     []                                          []                                   []   ",
            "                                    []                                            @                 []                                                                     []                                          []                                   []   ",
            "                                    []                                                              []                                                                     []                                          []                                   []   ",
            "         []                                                                                         []                                   []                                []                                          []                                   []   ",
            "         []                                                                                         []                                   []                                []                                          []                                   []   ",
            "         []                                                                                         []                                   []                                                                            []                                   []   ",
            "         []                                                                                         []                                   []                                                                            []                                   []   ",
            "         []                                                                                                                              []                                                                            []                                   []   ",
            "         []                                                                                                                              []                                                                            []                                   []   ",
            "         []                                                                                                                              []                                                                            []                                   []   ",
            "         []                                                                                                                              []                                                                            []                                   []   ",
            "         []                                                                                                                              []                                                                            []                                   []   "        
            },
            {
            "                                                                 []                                                                        []                                                                                                                []   ",
            "                                                                 []                                                                        []                []                                                                                              []   ",
            "                                                                 []                                                      @                 []                []                                                                                              []   ",
            "                                                                 []                                                                        []                []                                                                                              []   ",
            "                                                                 []                                                                                          []                                                                                              []   ",
            "                                                                 []                                                                                                                                                    []                                    []   ",
            "                                                                 []                      []                             []                                                                                             []                                    []   ",
            "                                                                 []                      []                             []                                                                                             []                                    []   ",
            "                                                                 []                      []                             []                                                                                             []                                    []   ",
            "                                                                                         []                                                []                                                                          []                                    []   ",
            "                                                                                         []                                                []                          []                                                                                    []   ",
            "                                                                                         []                                                []                          []                                                                                    []   ",
            "                                                                                         []                                                []                          []                                                                                    []   ",
            "                                            @                                            []                                                                            []                                                                                    []   ",
            "                                                                                         []                                                                            []                                                                                    []   ",
            "                                                                                         []                                                                                                                                                                  []   ",
            "                                                                                         []                                                                                                                                                                  []   ",
            "                                                                                         []                                                                                                                                                                  []   " 
            },
            {
            "                                              []                                               []                                                       []                                                                                                           []   ",
            "                                              []               @                               []                                                       []                                                                                                           []   ",
            "                                              []                                               []                                                       []                                                                                                           []   ",
            "                                              []                                               []                                                       []                                                                                                           []   ",
            "                                                                                               []                                                       []                                       []                                                                  []   ",
            "                                                                 []                            []                                                       []                                       []                                                                  []   ",
            "                                                                 []                                                            []                                                                []                                                                  []   ",
            "                                                                 []                                                            []                                                                []                                                                  []   ",
            "                                                                 []                                                            []                                  @                             []                                                                  []   ",
            "                                                                 []                                                            []                                                                []                                                                  []   ",
            "                                                                 []                                                            []                                                                []                                                                  []   ",
            "                                                                                                                                                        []                                       []                                                                  []   ",
            "                                                                                         []                                                             []                                                                                                           []   ",
            "                                                                                         []                                                             []                                                                                                           []   ",
            "                                                                                         []                                                             []                                                                                                           []   ",
            "                                                                                         []                            @                                []                                                                                                           []   ",
            "                                                                                         []                                                             []                                                                                                           []   ",
            "                                                                                         []                                                             []                                                                                                           []   " 
            },
            {
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                 []                                 []                                                                                                                            []                                                                             []   ",
            "                                 []                                 []                                                              []                                                            []                                                                             []   ",
            "                                 []                                 []                                                              []                                                            []                                                                             []   ",
            "                                 []                                 []                                    []                        []                                                            []                                                                             []   ",
            "                                 []                                 []                                    []                        []                []                                                                                                                         []   ",
            "                                 []                @                []                                    []                        []                []                                                                                                                         []   ",
            "                                                                    []                                    []                        []                []                           []                                []                                                          []   ",
            "                                                  []                                                      []                        []                []                           []                                []                                                          []   ",
            "                                                  []                                                                                []                                             []                                []                                                          []   ",
            "                                                  []                                                                                                                               []                                []                                                          []   ",
            "                                                  []                                                                          @                       @                            []                                []                                                          []   ",
            "                                                  []                               @                                                                                               []                                []                                                          []   ",
            "                                                  []                                                                                                                               []                                []                                                          []   ",
            "                                                                                                                                                                                                                                                                                 []   " 
            },
            {
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                                                                                                                                                                                  []                                                                             []   ",
            "                                 []                                 []                                                                                                                            []                                                                             []   ",
            "                                 []                                 []                                                              []                                                            []           @                                                                 []   ",
            "                                 []                                 []                                                              []                                                            []                                                                             []   ",
            "                                 []                                 []                                    []                        []                                                            []                                                                             []   ",
            "                                 []             @                   []                                    []                        []                []                                                                                                                         []   ",
            "                                 []                                 []                                    []                        []                []                                                                                                                         []   ",
            "                                                                    []                                    []                        []                []                           []                                []                                                          []   ",
            "                                                  []                                                      []                        []                []                           []                                []                                                          []   ",
            "                                                  []                                                                                []                                             []              @                 []                                                          []   ",
            "                                                  []                                                       @                                           @                           []                                []                                                          []   ",
            "                                                  []                                                                                                                               []                                []                                                          []   ",
            "                                                  []                                                                                                                               []                                []                                                          []   ",
            "                                                  []                                                                                                                               []                                []                                                          []   ",
            "                                                                                                                                                                                                                                                                                 []   " 
            }
        };

        private readonly int height;
        private int width;
        private int number;
        private int positionX;
        private int positionY;
        private List<LevelElements> elements;

        public Areas(int positionX, int positionY)
        {
            this.number = 0;
            this.height = this.levels.GetLength(1);
            this.width = this.levels[this.number, 0].Length;
            this.positionX = positionX;
            this.positionY = positionY;

            this.GetElements();
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
                if (this.number != this.levels.GetLength(0))
                {
                    this.width = this.levels[this.number, 0].Length;
                }
            }
        }

        public List<LevelElements> Elements
        {
            get
            {
                return this.elements;
            }
        }

        public string Name
        {
            get
            {
                return names[this.number];
            }
        }

        public string[] GetArea
        {
            get
            {
                string[] currentLevel = new string[this.height];
                for (int i = 0; i < this.height; i++)
                {
                    currentLevel[i] = this.levels[this.number, i];
                }

                this.width = currentLevel[0].Length;

                return currentLevel;
            }
        }

        public void GetElements()
        {
            this.elements = new List<LevelElements>();
            string[] currentLevel = this.GetArea;
            string[] temporyElement;
            StringBuilder elementColumn = new StringBuilder();
            int elementPositionX = 0;
            int elementPositionY = 0;

            for (int colIndex = 0; colIndex < currentLevel[0].Length; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < currentLevel.Length; rowIndex++)
                {
                    if (currentLevel[rowIndex][colIndex] != ' ')
                    {
                        if (elementColumn.Length == 0)
                        {
                            elementPositionX = colIndex;
                            elementPositionY = rowIndex;
                        }

                        elementColumn.Append(currentLevel[rowIndex][colIndex]);
                    }
                    else
                    {
                        if (elementColumn.Length != 0)
                        {
                            temporyElement = new string[elementColumn.Length];

                            for (int index = 0; index < elementColumn.Length; index++)
                            {
                                temporyElement[index] = elementColumn[index].ToString();
                            }

                            this.elements.Add(new LevelElements(temporyElement.Length, 1, this.positionX + elementPositionX, this.positionY + elementPositionY, temporyElement));
                            elementColumn = new StringBuilder();
                        }
                    }
                }

                if (elementColumn.Length != 0)
                {
                    temporyElement = new string[elementColumn.Length];

                    for (int index = 0; index < elementColumn.Length; index++)
                    {
                        temporyElement[index] = elementColumn[index].ToString();
                    }

                    this.elements.Add(new LevelElements(temporyElement.Length, 1, this.positionX + elementPositionX, this.positionY + elementPositionY, temporyElement));
                    elementColumn = new StringBuilder();
                }
            }

            this.MergeElements(this.elements);
        }

        public void Move()
        {
            this.positionX--;
            for (int index = 0; index < this.elements.Count; index++)
            {
                this.elements[index].PreviousPositionX = this.elements[index].PositionX;
                this.elements[index].PositionX--;
            }
        }

        public bool CheckForArea()
        {
            bool finish = false;

            if (this.number == this.levels.GetLength(0))
            {
                finish = true;
            }

            return finish;
        }

        public bool CheckForExit(int bonusCounter, int horseHeight)
        {
            bool exit = false;
            if (bonusCounter >= this.number + 1)
            {
                exit = true;
                this.OpenSezam(horseHeight);
            }

            return exit;
        }

        public void RemoveBonus(int rowPosiotion, int colPosition)
        {
            StringBuilder exit;

            exit = new StringBuilder();
            exit.Append(this.levels[this.number, rowPosiotion].Substring(0, colPosition));
            exit.Append(' ');
            exit.Append(this.levels[this.number, rowPosiotion].Substring(colPosition + 1, this.width - colPosition - 1));
            this.levels[this.number, rowPosiotion] = exit.ToString();

            this.GetElements();
        }

        private void MergeElements(List<LevelElements> elements)
        {
            for (int elementIndex = 0; elementIndex < elements.Count - 1; elementIndex++)
            {
                for (int afterElementIndex = 0; afterElementIndex < elements.Count; afterElementIndex++)
                {
                    if (elements[elementIndex].PositionX + 1 == elements[afterElementIndex].PositionX && elements[elementIndex].PositionY == elements[afterElementIndex].PositionY && elements[elementIndex].Element.Length == elements[afterElementIndex].Element.Length)
                    {
                        string[] temporaryElement = new string[elements[elementIndex].Element.Length];

                        for (int i = 0; i < temporaryElement.Length; i++)
                        {
                            temporaryElement[i] = elements[elementIndex].Element[i] + elements[afterElementIndex].Element[i];
                        }

                        elements[elementIndex].Element = temporaryElement;
                        elements.RemoveAt(afterElementIndex);
                        afterElementIndex--;
                    }
                }
            }
        }

        private void OpenSezam(int horseHeight)
        {
            StringBuilder exit = new StringBuilder();
            for (int row = 0; row < horseHeight; row++)
            {
                exit = new StringBuilder();
                exit.Append(this.levels[this.number, row + horseHeight].Substring(0, this.width - 10));
                for (int index = this.width - 10; index < this.width; index++)
                {
                    exit.Append(" ");
                }

                this.levels[this.number, row + horseHeight] = exit.ToString();
            }

            this.GetElements();
        }
    }
}