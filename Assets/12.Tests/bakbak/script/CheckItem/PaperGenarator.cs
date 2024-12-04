using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class PaperGenarator : MonoBehaviour
{
    public Permit permit;
    public TicketSetting ticket;
    public event Action OnGenerateEnd;

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
        GeneratePermit();
    }

    private void GeneratePermit()
    {
        string name = GetRandomBoolean(5) ?
            nameReader.GetRandomName(): baseName;
        Issuer issuer = GetRandomBoolean(5) ?
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

        if (GetRandomBoolean(5))
        {
            int randomDay = Random.Range(0, index);
            date = DataManager.Instance.calendarData[index - randomDay];
        }
        else
        {
            int randomDay = Random.Range(index , DataManager.Instance.calendarData.Count);
            date = DataManager.Instance.calendarData[index + randomDay];
        }

        List<Station> allowArea = new List<Station>
        {
            baseArea
        };
        List<Station> defaltArea = Enum.GetValues(typeof(Station)).Cast<Station>().ToList();
        defaltArea.Remove(Station.wrong);
        for (int i = 0; i <= Random.Range(Mathf.Max(defaltArea.Count/2,3),Mathf.Min(defaltArea.Count/2 +3, defaltArea.Count)); i++)
        {
            if (GetRandomBoolean(5))
            {
                allowArea.Add(Station.wrong);
            }
            else
            {
                Station temp = defaltArea[Random.Range(0, defaltArea.Count)];
                allowArea.Add(temp);
                defaltArea.Remove(temp);
            }
        }

        permit = new Permit(name, issuer, date, allowArea);
        GenerateTicket();

    }

    private void GenerateTicket()
    {
        string name = GetRandomBoolean(5) ?
            nameReader.GetRandomName() : baseName;

        Issuer issuer = GetRandomBoolean(5) ?
            Issuer.wrong :
            (Issuer)Random.Range(0, Enum.GetValues(typeof(Issuer)).Length - 1);

        int index = DataManager.Instance.calendarData.FindIndex(day => day == today);
        DayData date;

        if (GetRandomBoolean(95))
        {
            date = DataManager.Instance.calendarData[index];
        }
        else
        {
            int randomDay = Random.Range(0, DataManager.Instance.calendarData.Count);
            date = DataManager.Instance.calendarData[randomDay];
        }

        List<Station> include = new List<Station>(permit.allowArea);
        Station begin = Station.wrong;
        Station arrive = Station.wrong;

        if (GetRandomBoolean(95) && include.Count >= 2)
        {
            arrive = include[Random.Range(0, include.Count)];
            include.Remove(arrive);

            begin = include[Random.Range(0, include.Count)];
            include.Remove(begin);
        }
        else
        {
            begin = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
            arrive = (Station)Random.Range(0, Enum.GetValues(typeof(Station)).Length);
        }

        ticket = new TicketSetting(name, issuer, date, arrive, begin);
        OnGenerateEnd?.Invoke(); 
    }


    private bool GetRandomBoolean(float percentage)
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