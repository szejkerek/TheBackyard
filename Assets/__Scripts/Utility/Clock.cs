using UnityEngine;

/// <summary>
/// Represents a clock for measuring elapsed time.
/// </summary>
public class Clock
{
    private float startTimestamp = 0.0f;
    private float accumulatedTime = 0.0f;
    private bool isActive = false;

    /// <summary>
    /// Gets a value indicating whether the clock is currently running.
    /// </summary>
    public bool IsRunning => isActive;

    /// <summary>
    /// Initializes a new instance of the <see cref="Clock"/> class.
    /// </summary>
    public Clock()
    {
        startTimestamp = Time.time;
    }

    /// <summary>
    /// Advances the clock by a specified number of seconds.
    /// </summary>
    /// <param name="seconds">The number of seconds to forward the clock.</param>
    public void ForwardClockBy(float seconds)
    {
        accumulatedTime += seconds;
    }

    /// <summary>
    /// Starts the clock.
    /// </summary>
    public void Start()
    {
        isActive = true;
        startTimestamp = Time.time;
    }

    /// <summary>
    /// Stops the clock.
    /// </summary>
    public void Stop()
    {
        isActive = false;
        accumulatedTime += Time.time - startTimestamp;
    }

    /// <summary>
    /// Restarts the clock, resetting the accumulated time to zero.
    /// </summary>
    public void Restart()
    {
        accumulatedTime = 0.0f;
        Start();
    }

    /// <summary>
    /// Gets the elapsed time in seconds.
    /// </summary>
    /// <returns>The elapsed time in seconds.</returns>
    public float GetElapsedTimeInSeconds()
    {
        if (!isActive)
        {
            return accumulatedTime;
        }

        return accumulatedTime + (Time.time - startTimestamp);
    }

    /// <summary>
    /// Gets the elapsed time in milliseconds.
    /// </summary>
    /// <returns>The elapsed time in milliseconds.</returns>
    public float GetElapsedTimeInMilliseconds()
    {
        return GetElapsedTimeInSeconds() * 1000.0f;
    }

    /// <summary>
    /// Formats the specified milliseconds into a string representation in the format "mm:ss".
    /// </summary>
    /// <param name="milliseconds">The time in milliseconds to format.</param>
    /// <returns>A string representation of the time in "mm:ss" format.</returns>
    public static string FormatToMinSec(int milliseconds)
    {
        int seconds = milliseconds / 1000;
        int minutes = seconds / 60;
        seconds %= 60;

        return $"{minutes.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}";
    }
}