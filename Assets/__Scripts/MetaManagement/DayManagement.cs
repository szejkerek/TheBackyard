using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManagement : Singleton<DayManagement>
{
    [SerializeField] int timePerDay = 12;

    [SerializeField] TMP_Text timeText;

    [SerializeField] TMP_InputField possibleWin;
    [SerializeField] TMP_InputField possibleLoss;
    [SerializeField] TMP_InputField timeLoss;


    private void Start()
    {
        timeText.text = $"Time left: {timePerDay.ToString()}";
    }

    public void GoIntoArena() 
    {
        ArenaInformation info = GatherArenaInformatio();
        GameManager.Instance.SetArenaInformation(info);

        SceneManager.Instance.LoadScene(2);
    }

    private ArenaInformation GatherArenaInformatio()
    {
        ArenaInformation temp = new ArenaInformation();
        temp.character = null;
        temp.moneyWin = int.Parse(possibleWin.text);
        temp.moneyLoss = int.Parse(possibleLoss.text);
        temp.timeLoss = int.Parse(timeLoss.text);

        return temp;
    }
}
