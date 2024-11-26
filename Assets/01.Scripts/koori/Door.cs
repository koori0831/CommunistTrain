using Unity.Cinemachine;
using UnityEngine;

public class Door : ObjectInteract
{
    [SerializeField] private GameObject stationCam, Cam;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Reaching the moon");
        stationCam.SetActive(true);

        //Cam.transform.eulerAngles
    }
}
