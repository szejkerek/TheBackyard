using System;
using UnityEngine;

public class CycleManager
{
    public Action OnCycleEnded;
    public Action OnNewCycle;
    public Action OnNextDay;
    public Action OnNoMoreHoursLeft;

    public bool IsDay => isDay;
    public int CurrentDay => currentDay;
    public int HoursLeft => hoursLeft;

    bool isDay = false;
    int currentDay = 0;
    int hoursLeft;

    private int limitDays;
    private int timePerDay;

    public CycleManager(int limitDays, int timePerDay)
    {
        this.limitDays = limitDays;
        this.timePerDay = timePerDay;
        hoursLeft = timePerDay;
    }

    public void GoToNextCycle()
    {   
        if (!isDay)
        {
            StartDay();
        }
        else
        {
            StartNight();
        }
        OnNewCycle?.Invoke();
    }

    public void DecrementHours(int ammount)
    {
        hoursLeft -= ammount;
        if(hoursLeft < 0)
        {
            hoursLeft = 0;
            OnNoMoreHoursLeft?.Invoke();
        }
    }

    void StartDay()
    {
        isDay = true;
        hoursLeft = timePerDay;

        if (currentDay >= limitDays)
        {
            OnCycleEnded?.Invoke();
            return;
        }

        currentDay++;
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    void StartNight()
    {
        isDay = false;
        SceneManager.Instance.LoadScene(SceneEnum.NightManagementScene);
    }

    
}
