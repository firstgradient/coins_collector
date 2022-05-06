namespace BasicEvents
{
    public static class GameLogicEvents
    {
        public static readonly string GAME_OVER = typeof(GameLogicEvents).Name + "GAME_OVER";
        public static readonly string WIN = typeof(GameLogicEvents).Name + "WIN";
        public static readonly string RESTART = typeof(GameLogicEvents).Name + "RESTART";
        public static readonly string GAME_RULES_SENDED = typeof(GameLogicEvents).Name + "GAME_RULES_SENDED";

        public class GameRulesSendedEventArgs: BasicEventArgs
        {
            public GameRules GameRules { get; private set; }

            public GameRulesSendedEventArgs (GameRules gameRules)
            {
                GameRules = gameRules;
            }
        }
    }
}
