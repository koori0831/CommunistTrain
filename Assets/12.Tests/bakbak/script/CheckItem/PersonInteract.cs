using UnityEngine;

public class PersonInteract : ObjectInteract
{

    private CanvasControl _ticketCheckUI;
    private bool _alreadyInteract = false;

    private void Awake()
    {
        _ticketCheckUI = FindAnyObjectByType<CanvasControl>();
    }
    public override void Interact()
    {

        if (_ticketCheckUI.gameObject.activeSelf == false &&
            _ticketCheckUI != null &&
            !_alreadyInteract)
        {
            _alreadyInteract = true;
            _ticketCheckUI.FadeYoyo();
        }
    }
}
