using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PaperGenarator : MonoBehaviour
{
    public Permit permit;
    public TicketSetting ticketSetting;

    private DayData today;
    private NameReader nameReader;
    private Station baseArea;
    private string baseName;

    private void Awake()
    {
        baseArea = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
        today = DataManager.Instance.DayData;
        nameReader = GetComponent<NameReader>();
        baseName = nameReader.GetRandomName();
    }

    private void GenaratePermit()
    {
        string name = nameReader.GetRandomName();
        Issuer issuer = GetWrongValue(5) ?
            (Issuer)Enum.GetValues(typeof(Issuer)).Length :
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);
        DayData date = today;
        if (GetWrongValue(5))
        {
            throw new NotImplementedException();
            //이전 날짜
        }
        else
        {
            throw new NotImplementedException();
            //이후 날짜
        }

        List<Station> arrowArea = new List<Station>
        {
            baseArea
        };
        for (int i = 0; i < Random.Range(2,3); i++)
        {
            if (GetWrongValue(5))
            {
                arrowArea.Add(Station.wrong);
            }
            else
            {
                arrowArea.Add((Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length));
            }
        }

        permit = new Permit(name, issuer, date, arrowArea);
    }

    private bool GetWrongValue(float percentage)
    {
        float randomValue = Random.Range(0, 100f);
        if (randomValue > percentage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}