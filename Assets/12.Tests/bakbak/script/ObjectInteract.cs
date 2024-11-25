using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ObjectInteract : MonoBehaviour, IEnterInteractableHandler, IExitInteratableHandler

{
    private Bubble _interactionUI;
    [SerializeField]
    private Vector3 effectSize;
    [SerializeField]
    private Vector3 defaltSize;
    [SerializeField]
    private CanvasControl _ticetCheckUI;
    [SerializeField]
    private Transform _bubblePosition;

    [SerializeField] 
    private float effectDuration;

    public virtual void EnterInteraction()
    {
        _interactionUI = PoolManager.Instance.Pop("Bubble") as Bubble;
        _interactionUI.gameObject.SetActive(false);
        _interactionUI.transform.SetParent(transform);
        _interactionUI.transform.position = _bubblePosition.position;
        _interactionUI.transform.localScale = defaltSize;
        UIApear();
    }

    public virtual void Interact()
    {
        print("³»¿ë¹° Æ¡");
        if (_interactionUI.gameObject.activeSelf == false&&
            _ticetCheckUI != null)
        {
            _ticetCheckUI.FadeYoyo();
        }
    }

    public virtual void ExitInteraction()
    {
        UIDisapear();
        
    }

    private void UIApear()
    {
        _interactionUI.gameObject.SetActive(true);
        _interactionUI.transform.DOScale(effectSize, effectDuration).SetEase(Ease.InQuint);
    }
    
    private void UIDisapear()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_interactionUI.transform.DOScale(defaltSize, effectDuration).SetEase(Ease.InQuint))
            .AppendCallback(() => _interactionUI.gameObject.SetActive(false)).
            AppendCallback(() => PoolManager.Instance.Push(_interactionUI));
        sequence.Play();
    }
}
