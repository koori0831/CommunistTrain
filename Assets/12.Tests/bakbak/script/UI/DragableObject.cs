using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class DragableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected Vector2 _previousPositon = Vector2.zero;
    protected Image _dragableImage;

    public virtual void Awake()
    {
        _dragableImage = GetComponent<Image>();
        _dragableImage.raycastTarget = true;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousPositon = _dragableImage.rectTransform.anchoredPosition - eventData.position;
        _dragableImage.raycastTarget = false;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        _dragableImage.rectTransform.anchoredPosition = eventData.position+_previousPositon;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragableImage.raycastTarget=true;
    }
}
