using System;
using UnityEngine;

public class DayNightCycleManager : Singleton<DayNightCycleManager> 
{
    public bool IsDay => isDay;
    bool isDay = false;
    public Action OnCycleEnded;

    public Action OnNewCycle;
    public Action OnNextDay;
    public int CurrentDay => currentDay;
    int currentDay = 0;

    [SerializeField] private int LimitDays = 14;

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

    private void StartDay()
    {
        isDay = true;

        if (currentDay >= LimitDays)
        {
            OnCycleEnded?.Invoke();
            return;
        }

        currentDay++;
        SceneManager.Instance.LoadScene(0);
    }

    void StartNight()
    {
        isDay = false;
        SceneManager.Instance.LoadScene(1);
    }


}
