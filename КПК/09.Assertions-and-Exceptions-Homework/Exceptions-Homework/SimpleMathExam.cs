using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 2)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "Solved problems shoud be between 0 and 2");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 1:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 2:
                return new ExamResult(4, 2, 6, "Average result: 1 problem solved.");
            case 3:
                return new ExamResult(6, 2, 6, "Average result: 2 problem solved.");
            default:
                throw new ArgumentOutOfRangeException("ProblemsSolved", "Solved problems must be between 0 and 2.");
        }
    }
}
