using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TicketComponent : DragableObject, IDropHandler
{
    private RectTransform _passport, _hole;
    private Mask _holeMask;
    [SerializeField] private TextMeshProUGUI _issuer, _name, _takeDay, _station;

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
        _paperGenarator.OnGenerateEnd += SetTickt;
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

            if (targetComponent != null&&Punched==false)
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
        _issuer.text = _enumFactory.GetIssuerName(_paperGenarator.ticket.issuer);
        _name.text = _paperGenarator.ticket.name;
        _takeDay.text = $"{_paperGenarator.ticket.month.ToString()} / {_paperGenarator.ticket.date.ToString()} / {_paperGenarator.ticket.week.ToString()}";
        _station.text = _enumFactory.GetAreaString( _paperGenarator.ticket.beginingStation) + " to " + _enumFactory.GetAreaString(_paperGenarator.ticket.arriveStation);
    }
}
