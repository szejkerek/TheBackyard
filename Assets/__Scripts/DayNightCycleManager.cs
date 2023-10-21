using System;
using UnityEngine;

public class DayNightCycleManager : Singleton<DayNightCycleManager> 
{
    public bool IsDay => isDay;
    bool isDay = false;
    public Action OnCycleEnded;

    public Action OnNewCycle;
    public Action OnStartDay;
    public Action OnStartNight;
    public Action OnNextDay;
    public int CurrentDay => currentDay;
    int currentDay = 0;

    [SerializeField] private int LimitDays = 14;

    public void GoToNextCycle()
    {
        OnNewCycle?.Invoke();
        if (!isDay)
        {
            StartDay();
        }
        else
        {
            StartNight();
        }


    }

    void StartNight()
    {
        isDay = false;
        OnStartNight?.Invoke();
    }

    private void StartDay()
    {
        isDay = true;

        if (currentDay >= LimitDays)
        {
            OnCycleEnded?.Invoke();
            return;
        }

        currentDay++;
        OnStartDay?.Invoke();
    }
}
