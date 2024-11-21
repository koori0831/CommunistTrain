using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using Unity.VisualScripting;

public class PaperGenarator : MonoBehaviour
{
    public Permit permit;
    public TicketSetting ticket;
    public event Action OnGenarateEnd;

    public DayData today;
    private NameReader nameReader;
    private Station baseArea;
    private string baseName;

    private void Awake()
    {
        baseArea = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
        nameReader = GetComponent<NameReader>();
    }

    private void OnEnable()
    {
        today = DataManager.Instance.calendarData[0];//기본값 적용 후 수정 필요
        baseName = nameReader.GetRandomName();
        GenaratePermit();
    }

    private void GenaratePermit()
    {
        string name = GetRandomBoolen(5) ?
            nameReader.GetRandomName(): baseName;
        Issuer issuer = GetRandomBoolen(5) ?
            Issuer.wrong:
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);
        int index = 0;
        DayData date;
        try
        {
            index = DataManager.Instance.calendarData.FindIndex(day => day == today);
            date = DataManager.Instance.calendarData[index];
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message + " is not founded");
        }

        if (GetRandomBoolen(5))
        {
            int randomDay = Random.Range(0, index);
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
        List<Station> defaltArea = new List<Station>(Enum.GetValues(typeof(Station)).ConvertTo<List<Station>>());
        defaltArea.Remove(Station.wrong);
        defaltArea.Remove(baseArea);
        defaltArea.ForEach(s => print(s));
        for (int i = 0; i < Random.Range(2,4); i++)
        {
            if (GetRandomBoolen(5))
            {
                arrowArea.Add(Station.wrong);
            }
            else
            {
                Station temp = defaltArea[Random.Range(0, defaltArea.Count)];
                arrowArea.Add(temp);
                defaltArea.Remove(temp);
            }
        }

        permit = new Permit(name, issuer, date, arrowArea);
        GenarateTicket();

    }

    private void GenarateTicket()
    {
        string name = GetRandomBoolen(5) ?
            nameReader.GetRandomName() : baseName;

        Issuer issuer = GetRandomBoolen(5) ?
            Issuer.wrong :
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);

        int index = DataManager.Instance.calendarData.FindIndex(day => day == today);
        DayData date = DataManager.Instance.calendarData[index];

        if (GetRandomBoolen(95))
        {
            int randomDay = index;
            date = DataManager.Instance.calendarData[index];
        }
        else
        {
            int randomDay = Random.Range(0, DataManager.Instance.calendarData.Count);
            date = DataManager.Instance.calendarData[randomDay];
        }
        List<Station> include = permit.arrowArea;
        Station begin = Station.wrong;
        Station arrive = Station.wrong;

        if(GetRandomBoolen(95) == true)
        {
            arrive = include[Random.Range(0, include.Count)];
            include.Remove(arrive);
            begin = include[Random.Range(0, include.Count)];

        }
        else
        {
            begin = (Station)Random.Range(0,Enum.GetValues(typeof(Station)).Length);
            arrive = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
        }

        ticket = new TicketSetting(name, issuer, date, arrive, begin);
        OnGenarateEnd?.Invoke();

    }

    private bool GetRandomBoolen(float percentage)
    {
        float randomValue = Random.Range(0, 100f);
        if (randomValue < percentage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}