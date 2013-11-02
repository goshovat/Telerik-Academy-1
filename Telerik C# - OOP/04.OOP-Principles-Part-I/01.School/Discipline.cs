namespace _01.School
{
    using System;
    using System.Text;

    public class Discipline : ICommentable
    {
        private string name;
        private uint lecturesNumber;
        private uint exercisesNumber;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public uint LecturesNumber
        {
            get { return this.lecturesNumber; }
            set { this.lecturesNumber = value; }
        }
        
        public uint ExercisesNumber
        {
            get { return this.exercisesNumber; }
            set { this.exercisesNumber = value; }
        }

        public string Comment { get; set; }

        public Discipline(string name, uint lecturesNumber, uint exercisesNumber)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name!!!");
            }

            if (lecturesNumber < 0)
            {
                throw new ArgumentException("The number of lectures cannot be negative!!!");
            }

            if (exercisesNumber < 0)
            {
                throw new ArgumentException("The number of exersises cannot be negative!!!");
            }

            this.name = name;
            this.lecturesNumber = lecturesNumber;
            this.exercisesNumber = exercisesNumber;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(new string('~', Console.WindowWidth));

            output.AppendFormat("Name: {0}\nLecutres number = {1}\nExercises number = {2}\n{3}", 
                this.name, this.lecturesNumber, this.exercisesNumber, this.Comment != null ? "Comment: " + this.Comment + "\n" : "");

            output.Append(new string('~', Console.WindowWidth));

            return output.ToString();
        }
    }
}
