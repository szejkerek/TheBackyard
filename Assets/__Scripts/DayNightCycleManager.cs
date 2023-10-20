using System;
using UnityEngine;

public class DayNightCycleManager : Singleton<DayNightCycleManager> 
{
    public Action OnCycleEnded;
    public Action OnNextDay;
    public int CurrentDay => currentDay;
    int currentDay = 0;

    [SerializeField] private int LimitDays = 14;

    public void GoToNextDay()
    {
        currentDay++;
        if(currentDay >= LimitDays)
        {
            OnCycleEnded?.Invoke();
            return;
        }
        OnNextDay?.Invoke();
    }

}
