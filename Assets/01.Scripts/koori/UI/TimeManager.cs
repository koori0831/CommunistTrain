using System;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public int Times { get; private set; }

    public event Action OnSpendTime;

    public void SpendTime(int useTime = 1)
    {
        Times -= useTime;
        OnSpendTime?.Invoke();
    }
    public void RestTime()
    {
        Times = 4;
    }
}
