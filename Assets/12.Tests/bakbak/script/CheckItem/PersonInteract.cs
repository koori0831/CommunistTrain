using UnityEngine;

public class PersonInteract : ObjectInteract
{

    private CanvasControl _ticketCheckUI;

    private void Awake()
    {
        _ticketCheckUI = FindAnyObjectByType<CanvasControl>();
    }
    public override void Interact()
    {

        if (_ticketCheckUI.gameObject.activeSelf == false &&
            _ticketCheckUI != null)
        {
            _ticketCheckUI.FadeYoyo();
        }
    }
}
