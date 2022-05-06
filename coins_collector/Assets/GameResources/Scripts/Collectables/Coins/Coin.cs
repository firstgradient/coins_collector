using UnityEngine;
using BasicEvents;

public class Coin : BaseCollectable
{
    [SerializeField]
    private int _score = 0;

    protected override void Collected()
    {
        BasicEventManager.PublishEvent(ScoreEvents.ADD_SCORE, new ScoreEvents.AddScoreEventArgs(_score));
    }
}
