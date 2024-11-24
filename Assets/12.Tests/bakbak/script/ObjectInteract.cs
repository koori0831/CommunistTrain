using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ObjectInteract : MonoBehaviour, IEnterInteractableHandler, IExitInteratableHandler

{
    private GameObject _interactionUI;
    [SerializeField]
    private Vector3 effectSize;
    [SerializeField]
    private Vector3 defaltSize;
    [SerializeField]
    private CanvasControl _ticetCheckUI;

    [SerializeField] 
    private float effectDuration;

    public string PoolName => throw new System.NotImplementedException();

    public GameObject ObjectPrefab => throw new System.NotImplementedException();

    public virtual void EnterInteraction()
    {
        _interactionUI = PoolManager.Instance.Pop("Bubble").ObjectPrefab;
        _interactionUI.gameObject.SetActive(false);
        _interactionUI.transform.SetParent(transform);
        _interactionUI.transform.localScale = defaltSize;
        UIApear();
    }

    public virtual void Interact()
    {
        print("³»¿ë¹° Æ¡");
        _ticetCheckUI.FadeYoyo();
    }

    public virtual void ExitInteraction()
    {
        UIDisapear();
        _interactionUI.gameObject.SetActive(false);
        PoolManager.Instance.Push(_interactionUI.GetComponent<Ipoolable>());
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
            .AppendCallback(() => _interactionUI.gameObject.SetActive(false));
        sequence.Play();
    }
}
