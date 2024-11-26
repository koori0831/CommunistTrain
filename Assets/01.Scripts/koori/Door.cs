using Unity.Cinemachine;
using UnityEngine;

public class Door : ObjectInteract
{
    [SerializeField] private GameObject stationCam;
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
        stationCam.SetActive(true);
    }
}
