
namespace BasicEvents
{
    public static class UIEvents
    {
        public static readonly string SET_REMAINING_TIME = typeof(UIEvents) + "SET_REMAINING_TIME";
        public static readonly string SET_CURRENT_SCORE = typeof(UIEvents) + "SET_CURRENT_SCORE";
        public static readonly string SET_GOAL = typeof(UIEvents) + "SET_GOAL";

        public class SetRemainingTimeEventArgs : BasicEventArgs
        {
            public int RemainingTime { get; private set; }

            public SetRemainingTimeEventArgs(int remainingTime)
            {
                RemainingTime = remainingTime;
            }
        }

        public class SetCurrentScoreEventArgs : BasicEventArgs
        {
            public int Score { get; private set; }

            public SetCurrentScoreEventArgs(int score)
            {
                Score = score;
            }
        }

        public class SetGoalEventArgs : BasicEventArgs
        {
            public int Goal { get; private set; }

            public SetGoalEventArgs(int goal)
            {
                Goal = goal;
            }
        }
    }
}
