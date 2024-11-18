using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ReturnArea : MonoBehaviour, IDropHandler
{
    private TicketComponent _ticketComponent;
    private PermitComponent _permitComponent;
    private PaperGenarator _paperGenarator;
    [SerializeField] float returnPos, returnDuration;

    public event Action<bool> OnReturnPaper;
    private void Awake()
    {
        _paperGenarator = transform.parent.GetComponentInChildren<PaperGenarator>();
        _ticketComponent = _paperGenarator.gameObject.GetComponentInChildren<TicketComponent>();
        _permitComponent = _paperGenarator.gameObject.GetComponentInChildren<PermitComponent>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (_ticketComponent.Punched == true)
        {
            droppedObject.transform.parent = transform;
            Sequence moveDroppedObject = DOTween.Sequence();
            moveDroppedObject.Append(droppedObject.GetComponent<RectTransform>().DOAnchorPosY(returnPos, returnDuration).SetEase(Ease.OutQuint)).
                AppendCallback(() => droppedObject.SetActive(false));
            moveDroppedObject.Play();

            if (_paperGenarator.transform.childCount <= 0)
            {
                OnReturnPaper?.Invoke(ComparePaper());
                print(CompareIssuer());
                print(CompareArea());
                print(CompareDay());
                print(CompareName());
            }
        }
    }

    private bool ComparePaper()
    {
        if(_ticketComponent.Punched == true&& 
            CompareIssuer()&&
            CompareArea()&&
            CompareDay()&&
            CompareName())
        {
            return true;
        }
            
        return false;
    }

    private bool CompareIssuer()
    {
        if (_paperGenarator.permit.issuer == _paperGenarator.ticket.issuer)
            return true;
        return false;
    }
    private bool CompareArea()
    {
        if(_paperGenarator.permit.arrowArea.Contains(_paperGenarator.ticket.beginingStation)&&
            _paperGenarator.permit.arrowArea.Contains(_paperGenarator.ticket.arriveStation))
        {
            return true;
        }
        return false;
    }

    private bool CompareDay()
    {
        int today = DataManager.Instance.calendarData.FindIndex(day => DataManager.Instance.calendarData.Contains(_paperGenarator.today));//기본값 적용후 수정 필요
        int permitIndex = DataManager.Instance.calendarData.FindIndex(day => DataManager.Instance.calendarData.Contains(_paperGenarator.permit.day));
        int ticketIndex = DataManager.Instance.calendarData.FindIndex(day => DataManager.Instance.calendarData.Contains(_paperGenarator.ticket.day));
        if (permitIndex >= today&&ticketIndex<=today)
            return true;
        return false;   
    }

    private bool CompareName()
    {
        if(_paperGenarator.permit.name == _paperGenarator.ticket.name)
            return true;
        return false;
    }
}
