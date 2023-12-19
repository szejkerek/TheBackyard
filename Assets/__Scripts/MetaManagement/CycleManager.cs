using System;
using UnityEngine;

/// <summary>
/// Manages the game cycle, handling day and night transitions, hour management, and invoking events for cycle-related actions.
/// </summary>
public class CycleManager
{
    /// <summary>
    /// Event triggered when the current cycle ends.
    /// </summary>
    public Action OnCycleEnded;

    /// <summary>
    /// Event triggered at the start of a new cycle.
    /// </summary>
    public Action OnNewCycle;

    /// <summary>
    /// Event triggered at the start of a new day.
    /// </summary>
    public Action OnNextDay;

    /// <summary>
    /// Event triggered when there are no more hours left in the current cycle.
    /// </summary>
    public Action OnNoMoreHoursLeft;

    /// <summary>
    /// Indicates whether it is currently daytime.
    /// </summary>
    public bool IsDay => isDay;

    /// <summary>
    /// Gets the current day of the cycle.
    /// </summary>
    public int CurrentDay => currentDay;

    /// <summary>
    /// Gets the remaining hours in the current cycle.
    /// </summary>
    public int HoursLeft => hoursLeft;

    private bool isDay = false;
    private int currentDay = 0;
    private int hoursLeft;

    private int limitDays;
    private int timePerDay;

    /// <summary>
    /// Initializes a new instance of the CycleManager class.
    /// </summary>
    /// <param name="limitDays">The maximum number of days in the cycle.</param>
    /// <param name="timePerDay">The duration of each day in hours.</param>
    public CycleManager(int limitDays, int timePerDay)
    {
        this.limitDays = limitDays;
        this.timePerDay = timePerDay;
        hoursLeft = timePerDay;
    }

    /// <summary>
    /// Moves to the next cycle, either starting a new day or night based on the current state.
    /// </summary>
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

    /// <summary>
    /// Decreases the remaining hours in the current cycle.
    /// </summary>
    /// <param name="amount">The amount to decrement the hours.</param>
    public void DecrementHours(int amount)
    {
        hoursLeft -= amount;
        if (hoursLeft < 0)
        {
            hoursLeft = 0;
            OnNoMoreHoursLeft?.Invoke();
        }
    }

    /// <summary>
    /// Starts a new day in the cycle, transitioning to the day management scene.
    /// </summary>
    private void StartDay()
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
        OnNextDay?.Invoke();
    }

    /// <summary>
    /// Starts a new night in the cycle, transitioning to the night management scene.
    /// </summary>
    private void StartNight()
    {
        isDay = false;
        SceneManager.Instance.LoadScene(SceneEnum.NightManagementScene);
    }
}
