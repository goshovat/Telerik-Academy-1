public class Result
{
    private string name;
    private int score;

    public Result(string name = "", int score = 0)
    {
        this.Name = name;
        this.Score = score;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            this.name = value;
        }
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            this.score = value;
        }
    }
}