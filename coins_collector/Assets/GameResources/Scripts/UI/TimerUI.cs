using UnityEngine;
using BasicEvents;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private TMP_Text _text = null;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        BasicEventManager.StartListening(UIEvents.SET_REMAINING_TIME, OnSetRemainingTime);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(UIEvents.SET_REMAINING_TIME, OnSetRemainingTime);
    }

    private void SetRemainingTime(int time)
    {
        _text.text = "Time: " + time.ToString();
    }

    #region EventHandlers

    private void OnSetRemainingTime(BasicEventArgs eventArgs)
    {
        UIEvents.SetRemainingTimeEventArgs e = (UIEvents.SetRemainingTimeEventArgs)eventArgs;
        SetRemainingTime(e.RemainingTime);
    }

    #endregion
}
