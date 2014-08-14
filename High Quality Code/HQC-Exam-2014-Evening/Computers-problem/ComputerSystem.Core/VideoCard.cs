namespace ComputerSystem.Core
{
    using System;

    public class VideoCard
    {
        private bool isMonochrome;

        public VideoCard()
            : this(true)
        {
        }

        public VideoCard(bool isMonochrome)
        {
            this.isMonochrome = isMonochrome;
        }

        public bool IsMonochrome
        {
            get
            {
                return this.isMonochrome;
            }

            set
            {
                this.isMonochrome = value;
            }
        }

        public void Draw(string data)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(data);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(data);
                Console.ResetColor();
            }
        }
    }
}
