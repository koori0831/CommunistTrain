using System;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public int Times { get; private set; }

    public event Action OnSpendTime;
    public event Action OnTimeAllUesd;

    public void SpendTime(int useTime = 1)
    {
        Times -= useTime;
        if (Times == 0)
        {
            OnTimeAllUesd?.Invoke();
            return;
        }
        OnSpendTime?.Invoke();
    }
    public void RestTime()
    {
        Times = 4;
    }
}
