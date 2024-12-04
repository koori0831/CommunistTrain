using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Door : ObjectInteract
{
    [SerializeField] private GameObject stationCam, spawnPos;
    [SerializeField] private NavMeshAgent agent;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Reaching the moon");
        _animator.SetTrigger("Open");

    }
    public void OpenDoor()
    {
        agent.Warp(spawnPos.transform.position);
        agent.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
        stationCam.SetActive(true);
    }
}
