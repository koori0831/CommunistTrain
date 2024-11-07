using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Passport : DragableObject, IDropHandler
{
    private RectTransform _passport, _hole;
    private Mask _holeMask;

    public override void Awake()
    {
        base.Awake();
        _hole = _dragableImage.transform.GetChild(0).GetComponent<RectTransform>();
        _passport = _hole.transform.GetChild(0).GetComponent<RectTransform>();
        _holeMask = _hole.GetComponent<Mask>();
    }

    private void OnEnable()
    {
        _holeMask.enabled = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform droppedObject = eventData.pointerDrag.GetComponent<RectTransform>();

        print(droppedObject.name);

        if (droppedObject != null)
        {
            
            Cliper targetComponent = droppedObject.GetComponent<Cliper>(); 

            if (targetComponent != null)
            {
                _hole.anchoredPosition = droppedObject.anchoredPosition - _dragableImage.rectTransform.anchoredPosition;
                _passport.anchoredPosition = -_hole.anchoredPosition;
                _holeMask.enabled = true;
            }
            else
            {
                Debug.Log("일치하는 컴포넌트가 없습니다.");
            }
        }
    }
}
