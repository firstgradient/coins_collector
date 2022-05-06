using UnityEngine;
using BasicEvents;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameRules _rules = null;


    private void Awake()
    {
        BasicEventManager.StartListening(GameLogicEvents.RESTART, OnRestart);
    }

    private void Start()
    {
        BasicEventManager.PublishEvent(GameLogicEvents.GAME_RULES_SENDED, new GameLogicEvents.GameRulesSendedEventArgs(_rules));
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(GameLogicEvents.RESTART, OnRestart);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region EventHandlers

    private void OnRestart(BasicEventArgs eventArgs)
    {
        RestartGame();
    }

    #endregion
}
