using UnityEngine;
using BasicEvents;
using TMPro;

public class GoalUI : MonoBehaviour
{
    private TMP_Text _text = null;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        BasicEventManager.StartListening(UIEvents.SET_GOAL, OnSetGoal);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(UIEvents.SET_GOAL, OnSetGoal);
    }

    #region EventHandler
    private void OnSetGoal(BasicEventArgs eventArgs)
    {
        UIEvents.SetGoalEventArgs e = (UIEvents.SetGoalEventArgs)eventArgs;
        _text.text = "Goal: " + e.Goal.ToString();
    }
    #endregion
}
