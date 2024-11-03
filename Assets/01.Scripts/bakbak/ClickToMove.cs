using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent _agentNavMesh;
    private InputSystem_Actions _inputActions;

    public event Action OnMoveStart;
    public event Action OnArrive;
    private void Awake()
    {
        _agentNavMesh = GetComponent<NavMeshAgent>(); 

        _inputActions = new InputSystem_Actions();
        _inputActions.Player.Enable();
        _inputActions.Player.MoveRequest.performed += ClickToMoveCall;

    }

    private void Update()
    {
        if (_agentNavMesh.remainingDistance <= _agentNavMesh.stoppingDistance && !_agentNavMesh.hasPath)
        {
            OnArrive?.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (_inputActions != null)
        {
            _inputActions.Player.MoveRequest.performed -= ClickToMoveCall;
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
            OnMoveStart?.Invoke();
        }
    }
}
