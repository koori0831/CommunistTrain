using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public DayData DayData { get; set; }
    public int Money { get; set; } = 1234;
}
