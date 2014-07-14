using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade cannot be negative.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "Min grade cannot be negative.");
        }

        if (maxGrade < 0)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Max grade cannot be negative.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Max grade should be bigger than min grade.");
        }

        if (grade < minGrade || grade > maxGrade)
        {
            throw new ArgumentOutOfRangeException("grade", string.Format("Grade must be in the range between {0} and {1}.", minGrade, maxGrade));
        }

        if (comments == null)
        {
            throw new ArgumentNullException("comments", "Comments cannot be null.");
        }

        if (comments == string.Empty)
        {
            throw new ArgumentException("Comments cannot be emplty.", "comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
