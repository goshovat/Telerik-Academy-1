namespace Size
{
    internal class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public override string ToString()
        {
            string sizeString = string.Format("Width = {0}, Height={1}", this.Width, this.Height);
            return sizeString;
        }
    }
}
