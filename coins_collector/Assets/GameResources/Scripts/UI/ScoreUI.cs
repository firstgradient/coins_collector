using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasicEvents;
using TMPro;

public class ScoreUI : MonoBehaviour
{

    private TMP_Text  _text = null;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        BasicEventManager.StartListening(UIEvents.SET_CURRENT_SCORE, OnSetCurrentScore);
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(UIEvents.SET_CURRENT_SCORE, OnSetCurrentScore);
    }

    #region EventHandlers
    private void OnSetCurrentScore(BasicEventArgs eventArgs)
    {
        UIEvents.SetCurrentScoreEventArgs e = (UIEvents.SetCurrentScoreEventArgs)eventArgs;
        _text.text = "Score: " + e.Score.ToString();
    }
    #endregion
}
