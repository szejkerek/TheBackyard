using System;
using System.Collections.Generic;

/// <summary>
/// Represents a timer with the ability to trigger an action at specified intervals.
/// </summary>
public class TriggerTimer
{
    private Action triggerAction;
    private float interval = 0.0f;
    private float timePassed = 0.0f;
    private bool isActive = false;
    private bool isSingleShot = false;

    /// <summary>
    /// Gets the interval (in milliseconds) at which the timer triggers.
    /// </summary>
    public float Interval => interval;

    /// <summary>
    /// Gets the time passed (in milliseconds) since the timer started or last triggered.
    /// </summary>
    public float TimePassed => timePassed;

    /// <summary>
    /// Gets the time left (in milliseconds) until the next trigger.
    /// </summary>
    public float TimeLeft => interval - timePassed;

    /// <summary>
    /// Gets a value indicating whether the timer is currently active.
    /// </summary>
    public bool IsActive => isActive;

    /// <summary>
    /// Gets a value indicating whether the timer is set for a single-shot trigger.
    /// </summary>
    public bool IsSingleShot => isSingleShot;

    /// <summary>
    /// Sets the interval for the timer.
    /// </summary>
    /// <param name="intervalInMilliseconds">The interval in milliseconds.</param>
    public void SetInterval(float intervalInMilliseconds)
    {
        interval = intervalInMilliseconds;
    }

    /// <summary>
    /// Sets whether the timer is a single-shot timer.
    /// </summary>
    /// <param name="flag">True if the timer is a single-shot timer; otherwise, false.</param>
    public void SetSingleShot(bool flag)
    {
        isSingleShot = flag;
    }

    /// <summary>
    /// Sets the action to trigger when the timer interval is reached.
    /// </summary>
    /// <param name="action">The action to trigger.</param>
    public void SetTriggerFunction(Action action)
    {
        triggerAction = action;
    }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void Start()
    {
        isActive = true;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void Stop()
    {
        isActive = false;
    }

    /// <summary>
    /// Restarts the timer, resetting the time passed to zero.
    /// </summary>
    public void Restart()
    {
        isActive = true;
        timePassed = 0.0f;
    }

    /// <summary>
    /// Updates the timer based on the elapsed time.
    /// </summary>
    /// <param name="deltaTimeInMilliseconds">The elapsed time in milliseconds.</param>
    public void Update(float deltaTimeInMilliseconds)
    {
        if (!isActive)
        {
            return;
        }

        timePassed += deltaTimeInMilliseconds;

        if (timePassed >= interval)
        {
            triggerAction?.Invoke();
            timePassed = isSingleShot ? float.MinValue : 0.0f;
        }
    }
}