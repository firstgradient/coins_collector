using UnityEngine;
using UnityEngine.UI;
using BasicEvents;

public class WinPanelUI : MonoBehaviour
{
    [SerializeField]
    private Button _retryButton = null;

    private void Awake()
    {
        _retryButton.onClick.AddListener(OnRetryButtonClick);
        BasicEventManager.StartListening(GameLogicEvents.WIN, OnWin);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _retryButton.onClick.RemoveListener(OnRetryButtonClick);
        BasicEventManager.StopListening(GameLogicEvents.WIN, OnWin);
    }

    #region EventHandlers
    private void OnRetryButtonClick()
    {
        BasicEventManager.PublishEvent(GameLogicEvents.RESTART, null);
    }

    private void OnWin(BasicEventArgs eventArgs)
    {
        gameObject.SetActive(true);
    }
    #endregion
}
