using System.Collections;
using UnityEngine;
using BasicEvents;

public class TimerManager : MonoBehaviour
{
    private int _maxTime = 0;

    private int _remainingTime = 0;

    private Coroutine _timerCoroutine = null;

    private void Awake()
    {
        BasicEventManager.StartListening(TimerEvents.ADD_REMAINING_TIME, OnAddRemainingTime);
        BasicEventManager.StartListening(GameLogicEvents.WIN, OnWin);
        BasicEventManager.StartListening(GameLogicEvents.GAME_RULES_SENDED, OnGameRulesSended);
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(TimerEvents.ADD_REMAINING_TIME, OnAddRemainingTime);
        BasicEventManager.StopListening(GameLogicEvents.WIN, OnWin);
        BasicEventManager.StopListening(GameLogicEvents.GAME_RULES_SENDED, OnGameRulesSended);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _remainingTime -= 1;
            BasicEventManager.PublishEvent(UIEvents.SET_REMAINING_TIME, new UIEvents.SetRemainingTimeEventArgs(_remainingTime));

            if (_remainingTime <= 0)
            {
                BasicEventManager.PublishEvent(GameLogicEvents.GAME_OVER, null);
                break;
            }
        }
    }

    #region EventHandlers
    private void OnAddRemainingTime(BasicEventArgs eventArgs)
    {
        TimerEvents.AddRemainingTimeEventArgs e = (TimerEvents.AddRemainingTimeEventArgs)eventArgs;
        _remainingTime += e.TimeBonus;
        _remainingTime = Mathf.Clamp(_remainingTime, 0, _maxTime);

        BasicEventManager.PublishEvent(UIEvents.SET_REMAINING_TIME, new UIEvents.SetRemainingTimeEventArgs((int)_remainingTime));
    }

    private void OnWin(BasicEventArgs eventArgs)
    {
        StopCoroutine(_timerCoroutine);
    }

    private void OnGameRulesSended(BasicEventArgs eventArgs)
    {
        GameLogicEvents.GameRulesSendedEventArgs e = (GameLogicEvents.GameRulesSendedEventArgs)eventArgs;

        _maxTime = e.GameRules.MaxTime;
        _remainingTime = _maxTime;

        BasicEventManager.PublishEvent(UIEvents.SET_REMAINING_TIME, new UIEvents.SetRemainingTimeEventArgs(_remainingTime));
        _timerCoroutine = StartCoroutine(Timer());
    }
    #endregion
}
