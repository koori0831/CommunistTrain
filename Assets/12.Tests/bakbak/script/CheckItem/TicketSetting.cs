using UnityEngine;

public class TicketSetting
{
    public string name;
    public Issuer issuer;
    public int month;
    public int date;
    public Week week;
    public Station arriveStation;
    public Station beginingStation;
    public DayData day;
    public TicketSetting (string name, Issuer issuer, DayData day, Station arriveStation, Station beginingStation)
    {
        this.name = name;
        this.issuer = issuer;
        month = day.Month;
        date = day.Day;
        week = day.DayOfWeek;
        this.day = day;
        this.arriveStation = arriveStation;
        this.beginingStation = beginingStation;
    }
}
public enum Station
{
    area1,
    area2,
    area3,
    area4,
    wrong
}

