namespace BasicEvents
{
    public static class ScoreEvents
    {
        public static readonly string ADD_SCORE = typeof(ScoreEvents).Name + "ADD_SCORE";
        public static readonly string REMOVE_SCORE = typeof(ScoreEvents).Name + "REMOVE_SCORE";

        public class AddScoreEventArgs : BasicEventArgs
        {
            public int Score { get; private set; }
            public AddScoreEventArgs(int score)
            {
                Score = score;
            }
        }
    }
}
