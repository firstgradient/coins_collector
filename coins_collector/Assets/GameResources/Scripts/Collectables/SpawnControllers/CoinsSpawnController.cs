using System.Collections.Generic;
using UnityEngine;
using BasicEvents;

public class CoinsSpawnController : MonoBehaviour
{
    public GameObject SpawnPointsHolder = null;

    public GameObject CoinPrefab = null;

    private List<Transform> _spawnPoints = new List<Transform>();

    private bool _isActive = true;


    private void Awake()
    {
        _isActive = true;

        BasicEventManager.StartListening(CoinsEvents.COIN_COLLECTED, OnCoinCollected);
        BasicEventManager.StartListening(GameLogicEvents.GAME_OVER, HandleGameOver);
        BasicEventManager.StartListening(GameLogicEvents.WIN, HandleWin);

        foreach (Transform child in SpawnPointsHolder.transform)
        {
            _spawnPoints.Add(child);
        }

        SpawnCoin(true);
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(CoinsEvents.COIN_COLLECTED, OnCoinCollected);
        BasicEventManager.StopListening(GameLogicEvents.GAME_OVER, HandleGameOver);
        BasicEventManager.StopListening(GameLogicEvents.WIN, HandleWin);
    }

    private void SpawnCoin(bool fullRange)
    {
        Transform spawnPoint = GetRandomSpawnPoint(fullRange);
        MoveSpawnPointBack(spawnPoint);

        Object.Instantiate(CoinPrefab, spawnPoint);
    }

    private Transform GetRandomSpawnPoint(bool fullRange)
    {
        int index = 0;

        if (fullRange)
            index = UnityEngine.Random.Range(0, _spawnPoints.Count);
        else
            index = UnityEngine.Random.Range(0, _spawnPoints.Count - 1);

        Transform spawnPoint = _spawnPoints[index];

        return spawnPoint;
    }

    private void MoveSpawnPointBack(Transform spawnPoint)
    {
        _spawnPoints.Remove(spawnPoint);
        _spawnPoints.Add(spawnPoint);
    }

    #region EventsHandlers
    private void OnCoinCollected(BasicEventArgs eventArgs)
    {
        if (_isActive)
        {
            SpawnCoin(false);
        }
    }

    private void HandleGameOver(BasicEventArgs eventArgs)
    {
        _isActive = false;
    }

    private void HandleWin(BasicEventArgs eventArgs)
    {
        _isActive = false;
    }

    #endregion
}
