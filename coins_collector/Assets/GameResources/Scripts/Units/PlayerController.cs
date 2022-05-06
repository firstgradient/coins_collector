using UnityEngine;
using UnityEngine.AI;
using BasicEvents;

public class PlayerController : MonoBehaviour
{

    private NavMeshAgent _agent = null;
    private Camera _cam = null;

    private bool _isActive = true;

    private void Awake()
    {
        BasicEventManager.StartListening(GameLogicEvents.GAME_OVER, OnGameOverEvent);
        BasicEventManager.StartListening(GameLogicEvents.WIN, OnWinEvent);

        _agent = GetComponent<NavMeshAgent>();
        _cam = Camera.main;

        _isActive = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isActive)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    private void OnDestroy()
    {
        BasicEventManager.StopListening(GameLogicEvents.GAME_OVER, OnGameOverEvent);
        BasicEventManager.StopListening(GameLogicEvents.WIN, OnWinEvent);

    }

    #region EventHandlers
    private void OnGameOverEvent(BasicEventArgs eventArgs)
    {
        _isActive = false;
        _agent.isStopped= true;
    }

    private void OnWinEvent(BasicEventArgs eventArgs)
    {
        _isActive = false;
        _agent.isStopped = true;
    }
    #endregion

}
