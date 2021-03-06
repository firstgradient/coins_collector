using UnityEngine;
using BasicEvents;

public class Coin : BaseCollectable
{
    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private int _timeBonus = 0;

    [SerializeField]
    private GameObject _collectedEffect;

    private void Awake()
    {
        BasicEventManager.StartListening(GameLogicEvents.GAME_OVER, OnGameOver);
        BasicEventManager.StartListening(GameLogicEvents.WIN, OnWin);
    }

    protected override void Collected()
    {
        BurstEffect();

        BasicEventManager.PublishEvent(CoinsEvents.COIN_COLLECTED, new CoinsEvents.CoinCollectedEventArgs(_score));
        BasicEventManager.PublishEvent(TimerEvents.ADD_REMAINING_TIME, new TimerEvents.AddRemainingTimeEventArgs(_timeBonus));
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(GameLogicEvents.GAME_OVER, OnGameOver);
        BasicEventManager.StopListening(GameLogicEvents.WIN, OnWin);
    }

    private void BurstEffect()
    {
        var newEffect = Object.Instantiate(_collectedEffect, transform.position, Quaternion.Euler(-90,0,0));
        Object.Destroy(newEffect, newEffect.GetComponent<ParticleSystem>().main.duration);
    }

    #region EventHandlers
    private void OnGameOver(BasicEventArgs eventArgs)
    {
        Destroying();
    }

    private void OnWin(BasicEventArgs eventArgs)
    {
        Destroying();
    }
    #endregion
}
