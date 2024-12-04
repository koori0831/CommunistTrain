using System.Collections.Generic;
using UnityEngine;

public class TaxManager : MonoBehaviour
{
    public List<TaxReceiptType> WageList = new List<TaxReceiptType>();
    public List<TaxReceiptType> DeductionList = new List<TaxReceiptType>();
    public List<TaxReceiptType> EtcList = new List<TaxReceiptType>();

    private void Awake()
    {
        CalenderManager.Instance.OnWeeklyChanged += ResultOpen;
    }

    private void ResetTaxList()
    {
        WageList.Clear();
        DeductionList.Clear();
        EtcList.Clear();
    }

    private void ResultOpen()
    {

    }
}
