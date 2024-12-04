using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public DayData DayData { get; set; }
    public List<DayData> calendarData = new List<DayData>();
    public int Money { get; set; } = 1234;
}
