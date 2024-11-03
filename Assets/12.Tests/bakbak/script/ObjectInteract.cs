using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteract : MonoBehaviour, IEnterInteractionHandler, IExitInterationHandler
{
    private Transform _interactionUI;
    private void Start()
    {
        _interactionUI = transform.GetChild(0);
        _interactionUI.gameObject.SetActive(false);
    }
    public void EnterInteraction()
    {
        _interactionUI.gameObject.SetActive(true);
    }

    public void ExitInteraction()
    {
        _interactionUI.gameObject.SetActive(false);
    }
}
