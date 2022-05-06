using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawnController : MonoBehaviour
{
    public GameObject SpawnPointsHolder = null;

    public GameObject CoinPrefab = null;

    private List<Transform> _spawnPoints = new List<Transform>();


    private void Awake()
    {
        foreach (Transform child in SpawnPointsHolder.transform)
        {
            _spawnPoints.Add(child);
        }

        SpawnCoin(true);
    }

    private void SpawnCoin(bool fullRange)
    {
        Transform spawnPoint = GetRandomSpawnPoint(fullRange);
        MoveSpawnPointBack(spawnPoint);

        Object.Instantiate(CoinPrefab,spawnPoint);
    }

    private Transform GetRandomSpawnPoint(bool fullRange)
    {
        int index = 0;

        if (fullRange)
            index = UnityEngine.Random.Range(0, _spawnPoints.Count);
        else
            index = UnityEngine.Random.Range(0, _spawnPoints.Count-1);

        Transform spawnPoint = _spawnPoints[index];

        return spawnPoint;
    }

    private void MoveSpawnPointBack(Transform spawnPoint)
    {
        _spawnPoints.Remove(spawnPoint);
        _spawnPoints.Add(spawnPoint);
    }
}
