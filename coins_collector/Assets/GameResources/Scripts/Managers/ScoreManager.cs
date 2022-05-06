using UnityEngine;
using BasicEvents;

public class ScoreManager : MonoBehaviour
{
    private int _scoreGoal = 0;

    private int _currentScore = 0;

    private void Awake()
    {
        _currentScore = 0;

        BasicEventManager.StartListening(CoinsEvents.COIN_COLLECTED, OnCoinCollected);
        BasicEventManager.StartListening(GameLogicEvents.GAME_RULES_SENDED, OnGameRulesSended);
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(CoinsEvents.COIN_COLLECTED, OnCoinCollected);
        BasicEventManager.StopListening(GameLogicEvents.GAME_RULES_SENDED, OnGameRulesSended);
    }

    #region EventsHandlers


    private void OnCoinCollected(BasicEventArgs eventArgs)
    {
        CoinsEvents.CoinCollectedEventArgs e = (CoinsEvents.CoinCollectedEventArgs)eventArgs;

        _currentScore += e.Score;
        BasicEventManager.PublishEvent(UIEvents.SET_CURRENT_SCORE, new UIEvents.SetCurrentScoreEventArgs(_currentScore));

        if (_currentScore >= _scoreGoal)
        {
            BasicEventManager.PublishEvent(GameLogicEvents.WIN, null);
        }
    }

    private void OnGameRulesSended(BasicEventArgs eventArgs)
    {
        GameLogicEvents.GameRulesSendedEventArgs e = (GameLogicEvents.GameRulesSendedEventArgs)eventArgs;

        _scoreGoal = e.GameRules.ScoreGoal;
        _currentScore = 0;

        BasicEventManager.PublishEvent(UIEvents.SET_CURRENT_SCORE, new UIEvents.SetCurrentScoreEventArgs(_currentScore));
        BasicEventManager.PublishEvent(UIEvents.SET_GOAL, new UIEvents.SetGoalEventArgs(_scoreGoal));
    }
    #endregion
}
