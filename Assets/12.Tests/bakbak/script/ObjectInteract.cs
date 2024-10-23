using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteract : MonoBehaviour, IEnterInteractionHandler, IExitInterationHandler
{
    public void EnterInteraction()
    {
        Debug.Log("Enter");
    }

    public void ExitInteraction()
    {
        Debug.Log("Exit");
    }
}
