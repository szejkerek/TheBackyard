using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock
{
    private float startTimestamp = 0.0f;
    private float accumulatedTime = 0.0f;
    private bool isActive = false;

    public bool IsRunning => isActive;

    public Clock()
    {
        startTimestamp = Time.time;
    }

    public void Start()
    {
        isActive = true;
        startTimestamp = Time.time;
    }

    public void Stop()
    {
        isActive = false;
        accumulatedTime += Time.time - startTimestamp;
    }

    public void Restart()
    {
        accumulatedTime = 0.0f;
        Start();
    }

    float GetElapsedTimeInSeconds()
    {
        return accumulatedTime + (Time.time - startTimestamp);
    }

    float GetElapsedTimeInMiliseconds()
    {
        return GetElapsedTimeInSeconds() * 1000.0f;
    }
}
