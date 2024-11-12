using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class PaperGenarator : MonoBehaviour
{
    public Permit permit;
    public TicketSetting ticketSetting;
    public event Action OnGenarateEnd;

    private DayData today;
    private NameReader nameReader;
    private Station baseArea;
    private string baseName;

    private void Awake()
    {
        baseArea = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
        nameReader = GetComponent<NameReader>();
    }

    private void Start()
    {
        today = DataManager.Instance.calendarData[0];
        baseName = nameReader.GetRandomName();
        GenaratePermit();
        GenarateTicket();
        OnGenarateEnd?.Invoke();
    }

    private void GenaratePermit()
    {
        string name = GetRandomBoolen(5) ?
            nameReader.GetRandomName(): baseName;
        Issuer issuer = GetRandomBoolen(5) ?
            (Issuer)Enum.GetValues(typeof(Issuer)).Length :
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);
        int index = 0;
        DayData date;
        try
        {
            index = DataManager.Instance.calendarData.FindIndex(day => DataManager.Instance.calendarData.Contains(today));
            date = DataManager.Instance.calendarData[index];
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message + " is not founded");
        }

        if (GetRandomBoolen(5))
        {
            int randomDay = Random.Range(0, index);
            print(index - randomDay);
            print($"{index} + {randomDay}");
            date = DataManager.Instance.calendarData[index - randomDay];
        }
        else
        {
            int randomDay = Random.Range(index , DataManager.Instance.calendarData.Count);
            date = DataManager.Instance.calendarData[index + randomDay];
        }

        List<Station> arrowArea = new List<Station>
        {
            baseArea
        };
        for (int i = 0; i < Random.Range(2,3); i++)
        {
            if (GetRandomBoolen(5))
            {
                arrowArea.Add(Station.wrong);
            }
            else
            {
                arrowArea.Add((Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length-1));
            }
        }

        permit = new Permit(name, issuer, date, arrowArea);
    }

    private void GenarateTicket()
    {
        string name = GetRandomBoolen(5) ?
            nameReader.GetRandomName() : baseName;
        Issuer issuer = GetRandomBoolen(5) ?
            (Issuer)Enum.GetValues(typeof(Issuer)).Length :
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);
        int index = DataManager.Instance.calendarData.FindIndex(day => DataManager.Instance.calendarData.Contains(today));
        DayData date = DataManager.Instance.calendarData[index];
        if (GetRandomBoolen(95))
        {
            int randomDay = Random.Range(0, index + 1);
            date = DataManager.Instance.calendarData[index - randomDay];
        }
        else
        {
            int randomDay = Random.Range(index, DataManager.Instance.calendarData.Count);
            date = DataManager.Instance.calendarData[index + randomDay];
        }

        List<Station> include = permit.arrowArea;
        Station begin = Station.wrong;
        Station arrive = Station.wrong;

        if(GetRandomBoolen(5) == true)
        {
            foreach (Station item in Enum.GetValues(typeof(Station)))
            {
                if (include.Contains(item) == false)
                {
                    if (GetRandomBoolen(50))
                    {
                        begin = item;
                    }
                    else
                    {
                        arrive = item;
                    }
                }
            }
        }
        else
        {
            begin = (Station)Random.Range(0,include.Count);
            arrive = (Station)Random.Range(0, include.Count);
        }

        ticketSetting = new TicketSetting(name, issuer, date, arrive, begin);
    }

    private bool GetRandomBoolen(float percentage)
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