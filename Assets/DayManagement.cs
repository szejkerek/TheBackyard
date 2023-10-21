using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManagement : Singleton<DayManagement>
{
    [SerializeField] int timePerDay = 12;
    [SerializeField] TMP_Text timeText;

    private void Start()
    {
        timeText.text = $"Time left: {timePerDay.ToString()}";
    }

}
