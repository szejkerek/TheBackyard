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

    public void ForwardClockBy(float seconds)
    {
        accumulatedTime += seconds;
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

    public float GetElapsedTimeInSeconds()
    {
        if(!isActive)
        {
            return accumulatedTime;
        }

        return accumulatedTime + (Time.time - startTimestamp);
    }

    public float GetElapsedTimeInMilliseconds()
    {
        return GetElapsedTimeInSeconds() * 1000.0f;
    }

    public static string FormatToMinSec(int milliseconds)
    {
        int seconds = milliseconds / 1000;
        int minutes = seconds / 60;
        seconds %= 60;

        return $"{minutes.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}";
    }
}
