using UnityEngine;

public class FlatformDoor : ObjectInteract
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("��.. �����ƾ�!");
        TimeManager.Instance.SpendTime(TimeManager.Instance.Times);
    }
}
