using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent _agentNavMesh;
    private InputSystem_Actions _inputActions;

    private Rigidbody _rb;

    private void Awake()
    {
        _agentNavMesh = GetComponent<NavMeshAgent>(); 

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.Enable();
        _inputActions.Player.Attack.performed += ClickToMoveCall;

        _rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        if (_inputActions != null)
        {
            _inputActions.Player.Attack.performed -= ClickToMoveCall;
            _inputActions.Player.Disable();
        }
    }

    public void ClickToMoveCall(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 randomOffset = Random.insideUnitSphere * 0.5f;
            randomOffset.y = 0;
            _agentNavMesh.destination = hitInfo.point + randomOffset;
        }
    }
}
