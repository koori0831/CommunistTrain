using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent _agentNavMesh;
    [SerializeField]
    private InputReader _inputReader;

    public event Action OnMoveStart;
    public event Action OnArrive;
    private void Awake()
    {
        _agentNavMesh = GetComponent<NavMeshAgent>();

        _inputReader.OnClick += ClickToMoveCall;

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
        if (_inputReader != null)
        {
            _inputReader.OnClick += ClickToMoveCall;
        }
    }

    public void ClickToMoveCall()
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

    public void Warp(Vector3 posioitn)
    {
        _agentNavMesh.enabled = false;
        _agentNavMesh.transform.position = posioitn;
        _agentNavMesh.enabled = true;
    }
}
