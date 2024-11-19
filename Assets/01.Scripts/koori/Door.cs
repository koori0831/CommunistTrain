using UnityEngine;

public class Door : ObjectInteract
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Reaching the moon");
    }
}
