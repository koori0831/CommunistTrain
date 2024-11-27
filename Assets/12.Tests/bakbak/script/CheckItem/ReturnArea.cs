using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class ReturnArea : MonoBehaviour, IDropHandler
{
    private TicketComponent _ticketComponent;
    private PermitComponent _permitComponent;
    private PaperGenarator _paperGenarator;

    private RectTransform _permitTransform;
    private RectTransform _ticketTransform;
    [SerializeField] float returnPos, returnDuration;

    public UnityEvent OnReturnPaper;

    private void Awake()
    {
        _paperGenarator = transform.parent.GetComponentInChildren<PaperGenarator>();
        _ticketComponent = _paperGenarator.gameObject.GetComponentInChildren<TicketComponent>();
        _permitComponent = _paperGenarator.gameObject.GetComponentInChildren<PermitComponent>();
        _permitTransform = _permitComponent.GetComponent<RectTransform>();
        _ticketTransform = _ticketComponent.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _permitTransform.SetParent(_paperGenarator.transform);
        _permitTransform.anchoredPosition = Vector3.zero;
        _permitTransform.gameObject.SetActive(true);
        _ticketTransform.SetParent(_paperGenarator.transform);
        _ticketTransform.anchoredPosition = Vector3.zero;
        _ticketTransform.gameObject.SetActive(true);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (_ticketComponent.Punched == true)
        {
            droppedObject.transform.parent = transform;
            Sequence moveDroppedObject = DOTween.Sequence();
            moveDroppedObject.Append(droppedObject.GetComponent<RectTransform>().DOAnchorPosY(returnPos, returnDuration).SetEase(Ease.OutQuint));
            moveDroppedObject.Play();

            if (_paperGenarator.transform.childCount <= 0)
            {
                OnReturnPaper?.Invoke();
                CheckingManager.Instance?.CompliemCheck(ComparePaper());
            }
        }
    }

    public void OnCallPolice()
    {
        OnReturnPaper?.Invoke();
        CheckingManager.Instance?.CompliemCheck(!ComparePaper());
    }

    private bool ComparePaper()
    {
        if( CompareIssuer()&&
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
        if (_paperGenarator.permit.issuer != Issuer.wrong&&_paperGenarator.ticket.issuer != Issuer.wrong)
            return true;
        return false;
    }
    private bool CompareArea()
    {
        if(_paperGenarator.ticket.beginingStation == Station.wrong) return false;
        if(_paperGenarator.ticket.arriveStation == Station.wrong) return false;
        if(_paperGenarator.permit.allowArea.Contains(_paperGenarator.ticket.beginingStation)&&
            _paperGenarator.permit.allowArea.Contains(_paperGenarator.ticket.arriveStation))
        {
            return true;
        }
        return false;
    }

    private bool CompareDay()
    {
        int today = DataManager.Instance.calendarData.FindIndex(day => day == _paperGenarator.today);//기본값 적용후 수정 필요
        int permitIndex = DataManager.Instance.calendarData.FindIndex(day => day==_paperGenarator.permit.day);
        int ticketIndex = DataManager.Instance.calendarData.FindIndex(day => day == _paperGenarator.ticket.day);
        if (permitIndex >= today&&ticketIndex==today)
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
