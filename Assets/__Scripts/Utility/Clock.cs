using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock
{
    private float startTimestamp;
    private bool isActive;

    public Clock()
    {
        startTimestamp = Time.time;
    }
}
