using UnityEngine;
using BasicEvents;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    private void Awake()
    {
        _score = 0;

        BasicEventManager.StartListening(ScoreEvents.ADD_SCORE, OnAddScoreEvent);
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(ScoreEvents.ADD_SCORE, OnAddScoreEvent);
    }

    #region EventsHandlers
    private void OnAddScoreEvent(BasicEventArgs eventArgs)
    {
        ScoreEvents.AddScoreEventArgs e = (ScoreEvents.AddScoreEventArgs)eventArgs;

        _score += e.Score;
        Debug.Log($"Current Score {_score}");
    }
    #endregion
}
