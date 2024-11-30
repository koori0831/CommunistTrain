using UnityEngine;

public class FlatformDoor : ObjectInteract
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("±â.. ±âÂ÷¾Æ¾Ñ!");
        TimeManager.Instance.SpendTime(TimeManager.Instance.Times);
    }
}
