using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ObjectInteract : MonoBehaviour, IEnterInteractableHandler, IExitInteratableHandler
{
    private Transform _interactionUI;
    [SerializeField]
    private Vector3 effectSize;
    [SerializeField]
    private Vector3 defaltSize;

    [SerializeField] 
    private float effectDuration;
    private void Start()
    {
        _interactionUI = transform.GetChild(0);
        _interactionUI.gameObject.SetActive(false);
        _interactionUI.transform.localScale = defaltSize;
    }
    public virtual void EnterInteraction()
    {
        UIApear();
    }

    public virtual void ExitInteraction()
    {
        UIDisapear();
    }

    private void UIApear()
    {
        _interactionUI.gameObject.SetActive(true);
        _interactionUI.DOScale(effectSize, effectDuration).SetEase(Ease.InQuint);
    }
    
    private void UIDisapear()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_interactionUI.DOScale(defaltSize, effectDuration).SetEase(Ease.InQuint))
            .AppendCallback(() => _interactionUI.gameObject.SetActive(false));
        sequence.Play();
    }
}
