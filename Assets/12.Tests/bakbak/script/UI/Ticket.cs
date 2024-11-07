using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ticket : DragableObject, IDropHandler
{
    private RectTransform _passport, _hole;
    private Mask _holeMask;

    public bool Punched {  get; private set; }

    public override void Awake()
    {
        base.Awake();
        _hole = _dragableImage.transform.GetChild(0).GetComponent<RectTransform>();
        _passport = _hole.transform.GetChild(0).GetComponent<RectTransform>();
        _holeMask = _hole.GetComponent<Mask>();
    }

    private void OnEnable()
    {
        Punched = false;
        _holeMask.enabled = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();


        if (droppedObject != null)
        {
            
            Cliper targetComponent = droppedObject.GetComponent<Cliper>(); 

            if (targetComponent != null)
            {
                _hole.anchoredPosition = droppedObject.anchoredPosition - _dragableImage.rectTransform.anchoredPosition;
                _passport.anchoredPosition = -_hole.anchoredPosition;
                _holeMask.enabled = true;
                Punched = true;
            }
        }
    }
}
