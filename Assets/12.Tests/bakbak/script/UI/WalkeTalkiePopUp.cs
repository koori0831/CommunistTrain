using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class WalkeTalkiePopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isPoped;
    private RectTransform _rectTransform;
    [SerializeField] private float effectPos, effectDuration;
    private float defalt;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        defalt = _rectTransform.anchoredPosition.x;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        if (isPoped == false)
        {
            _rectTransform.DOAnchorPosX(defalt + effectPos, effectDuration).SetEase(Ease.OutQuint);
        isPoped = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (isPoped == true)
        {
            _rectTransform.DOAnchorPosX(defalt, effectDuration).SetEase(Ease.OutQuint);
        isPoped = false;
        }
    }
}
