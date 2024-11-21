using System.Collections.Generic;
using UnityEngine;

public class Permit
{
    public string name;
    public Issuer issuer;
    public int month;
    public int date;
    public Week week;
    public DayData day;
    public List<Station> allowArea;

    public Permit(string settingName, Issuer issuerSetting, DayData date, List<Station> arrowAreas)
    {
        name = settingName;
        issuer = issuerSetting;
        month = date.Month;
        this.date = date.Day;
        week = date.DayOfWeek;
        day = date;
        allowArea = arrowAreas;
    }
}

public enum Issuer
{
    issuer1,
    issuer2, 
    issuer3, 
    issuer4, 
    issuer5, 
    issuer6, 
    wrong
}


