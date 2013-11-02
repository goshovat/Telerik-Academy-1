namespace _02.Human
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private ushort workHoursPerDay;

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Week salary cannot be negative!");
                }

                this.weekSalary = value;
            }
        }
        public ushort WorkHoursPerDay 
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        public Worker(string firstName, string lastName, double weekSalary, ushort workHoursPerDay) 
            : base(firstName, lastName)
        {
            if (weekSalary < 0)
            {
                throw new ArgumentException("Week salary cannot be negative!");
            }
            
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            double moneyPerHour = WeekSalary / (WorkHoursPerDay * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("Name: {0} {1}", firstName, lastName);
            output.AppendFormat("\nMoney per hour: {0:F2} lv.", MoneyPerHour());
            output.AppendFormat("\nWork hour per day: {0}", workHoursPerDay);
            output.AppendFormat("\nWeek salary: {0}\n", weekSalary);

            return output.ToString();
        }
    }
}
