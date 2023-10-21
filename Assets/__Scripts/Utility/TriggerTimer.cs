using System;
using System.Collections.Generic;

public class TriggerTimer
{
    private Action triggerAction;
    private float interval = 0.0f;
    private float timePassed = 0.0f;
    private bool isActive = false;
    private bool isSingleShot = false;

    public float Interval => interval;
    public float TimePassed => timePassed;
    public float TimeLeft => interval - timePassed;
    public bool IsActive => isActive;
    public bool IsSingleShot => isSingleShot;

    public void SetInterval(float intervalInMilliseconds)
    {
        interval = intervalInMilliseconds;
    }

    public void SetSingleShot(bool flag)
    {
        isSingleShot = flag;
    }

    public void SetTriggerFunction(Action action)
    {
        triggerAction = action;
    }

    public void Start()
    {
        isActive = true;
    }

    public void Stop()
    { 
        isActive = false; 
    }

    public void Restart()
    {
        isActive = true;
        timePassed = 0.0f;
    }

    public void Update(float deltaTimeInMilliseconds)
    {
        if(!isActive)
        {
            return;
        }

        timePassed += deltaTimeInMilliseconds;

        if(timePassed >= interval)
        {
            triggerAction?.Invoke();
            timePassed = isSingleShot ? float.MinValue : 0.0f;
        }
    }
}
