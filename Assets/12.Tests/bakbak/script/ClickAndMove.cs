using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAndMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _previousPositon;
    private Image _ticketImage;

    private void Awake()
    {
        _ticketImage = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _ticketImage.rectTransform.anchoredPosition = eventData.position+_previousPositon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _previousPositon = _ticketImage.rectTransform.anchoredPosition - eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
