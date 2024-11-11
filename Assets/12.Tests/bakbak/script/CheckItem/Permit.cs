using System.Collections.Generic;
using UnityEngine;

public class Permit
{
    public string name;
    public Issuer issuer;
    public int month;
    public int date;
    public List<Station> arrowArea;

    public Permit(string settingName, Issuer issuerSetting, DayData date, List<Station> arrowAreas)
    {
        name = settingName;
        issuer = issuerSetting;
        month = date.Month;
        this.date = date.Day;
        foreach (Station station in arrowAreas)
        {
            arrowArea.Add(station);
        }
    }
}

public enum Issuer
{
    issuer1,
    issuer2, issuer3, issuer4, issuer5, issuer6, wrong

}


