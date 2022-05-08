using UnityEngine;
using UnityEngine.UI;
using BasicEvents;

public class LosePanelUI : MonoBehaviour
{
    [SerializeField]
    private Button _retryButton = null;

    private void Awake()
    {
        _retryButton.onClick.AddListener(OnRetryButtonClick);
        BasicEventManager.StartListening(GameLogicEvents.GAME_OVER, OnGameOver);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _retryButton.onClick.RemoveListener(OnRetryButtonClick);
        BasicEventManager.StopListening(GameLogicEvents.GAME_OVER, OnGameOver);
    }

    #region EventHandlers
    private void OnGameOver(BasicEventArgs eventArgs)
    {
        gameObject.SetActive(true);
    }

    private void OnRetryButtonClick()
    {
        BasicEventManager.PublishEvent(GameLogicEvents.RESTART, null);
    }
    #endregion

}
