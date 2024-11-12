using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ticket : DragableObject, IDropHandler
{
    private RectTransform _passport, _hole;
    private Mask _holeMask;
    [SerializeField] private TextMeshProUGUI _issuer, _name, _takeDay, _startStation, _arriveStation;

    private PaperGenarator _paperGenarator;
    private EnumFactory _enumFactory;

    public bool Punched {  get; private set; }

    public override void Awake()
    {
        base.Awake();
        _hole = _dragableImage.transform.GetChild(0).GetComponent<RectTransform>();
        _passport = _hole.transform.GetChild(0).GetComponent<RectTransform>();
        _holeMask = _hole.GetComponent<Mask>();
        _paperGenarator = GetComponentInParent<PaperGenarator>();
        _enumFactory = GetComponentInParent<EnumFactory>();
        _paperGenarator.OnGenarateEnd += SetTickt;
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

    private void SetTickt()
    {
        _issuer.text = _enumFactory.GetIssuerName(_paperGenarator.ticketSetting.issuer);
        _name.text = _paperGenarator.ticketSetting.name;
        _takeDay.text = _paperGenarator.ticketSetting.date.ToString();
        _startStation.text = _enumFactory.GetAreaString( _paperGenarator.ticketSetting.beginingStation);
        _arriveStation.text = _enumFactory.GetAreaString(_paperGenarator.ticketSetting.beginingStation);
    }
}
