using UnityEngine;
using BasicEvents;

public class Coin : BaseCollectable
{
    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private int _timeBonus = 0;

    protected override void Collected()
    {
        BasicEventManager.PublishEvent(CoinsEvents.COIN_COLLECTED, null);
        BasicEventManager.PublishEvent(TimerEvents.ADD_REMAINING_TIME, new TimerEvents.AddRemainingTimeEventArgs(_timeBonus));
    }
}
