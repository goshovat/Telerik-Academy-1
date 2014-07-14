namespace PrintStatistics
{
    internal class Statistic
    {
        private double[] numbers;

        public Statistic(double[] numbers)
        {
            this.Numbers = numbers;
        }

        public double[] Numbers
        {
            get
            {
                return this.numbers;
            }

            set
            {
                this.numbers = value;
            }
        }

        /// <summary>
        /// Find the maximal value from the numbers
        /// </summary>
        /// <returns>Maximal number</returns>
        public double GetMaxValue()
        {
            double max = double.MinValue;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                if (this.Numbers[i] > max)
                {
                    max = this.Numbers[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Find the minimal value from the numbers
        /// </summary>
        /// <returns>Minimal number</returns>
        public double GetMinValue()
        {
            double min = double.MaxValue;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                if (this.Numbers[i] < min)
                {
                    min = this.Numbers[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Calculate the average value from the numbers
        /// </summary>
        /// <returns>Average number</returns>
        public double GetAverageValue()
        {
            double totalSum = 0;

            for (int i = 0; i < this.Numbers.Length; i++)
            {
                totalSum += this.Numbers[i];
            }

            double average = totalSum / this.Numbers.Length;

            return average;
        }
    }
}
