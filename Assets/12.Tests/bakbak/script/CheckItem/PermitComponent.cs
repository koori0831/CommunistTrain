using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PermitComponent : DragableObject
{
    [SerializeField] private TextMeshProUGUI _name, _issuer, _takeDay, _arrowArea;
    private EnumFactory enumFactory;

    private PaperGenarator _paperGenarator;
    public override void Awake()
    {
        base.Awake();
        _paperGenarator = GetComponentInParent<PaperGenarator>();
        _paperGenarator.OnGenerateEnd += SetPaper;
        enumFactory = GetComponentInParent<EnumFactory>();
    }

    private void SetPaper()
    {
        _name.text = _paperGenarator.permit.name;
        _issuer.text = enumFactory.GetIssuerName(_paperGenarator.permit.issuer);
        _takeDay.text = $"{_paperGenarator.ticket.month} / {_paperGenarator.ticket.date} / {_paperGenarator.ticket.week}";
        _arrowArea.text = GetAreaString();
    }

    private string GetAreaString()
    {
        string result = string.Empty;
        foreach (Station station in _paperGenarator.permit.allowArea)
        {
            result += enumFactory.GetAreaString(station) + " ";
        }
        return result;
    }
}
