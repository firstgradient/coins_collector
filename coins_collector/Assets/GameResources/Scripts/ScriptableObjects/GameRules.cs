using UnityEngine;

[CreateAssetMenu(fileName = "GameRules", menuName = "ScriptableObjects/GameRules")]
public class GameRules : ScriptableObject
{
    [SerializeField]
    private int _scoreGoal = 0;
    [SerializeField]
    private int _maxTime = 0;

    public int ScoreGoal => _scoreGoal;
    public int MaxTime => _maxTime;
}
