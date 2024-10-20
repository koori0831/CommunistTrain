using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private InputSystem_Actions _inputActions;

    private Rigidbody _rb;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>(); 

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.Enable();
        _inputActions.Player.MoveRequest.performed += ClickToMoveCall;

        _rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        if (_inputActions != null)
        {
            _inputActions.Player.MoveRequest.performed -= ClickToMoveCall;
            _inputActions.Player.Disable();
        }
    }

    private void Update()
    {
        print(_agent.velocity);
    }

    public void ClickToMoveCall(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 randomOffset = Random.insideUnitSphere * 0.5f;
            randomOffset.y = 0;
            _agent.destination = hitInfo.point + randomOffset;
        }
    }
}
