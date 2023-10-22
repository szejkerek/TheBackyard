using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanel : MonoBehaviour
{
    [SerializeField] private MiniGameSO minigame;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Image preview;
    [SerializeField] TextMeshProUGUI possibleWin;
    [SerializeField] TextMeshProUGUI possibleLost;
    [SerializeField] TextMeshProUGUI timeSpend;
    [SerializeField] Button applyButton;

    [Header("UI")]

    ArenaInformation tempArenaInfo = new ArenaInformation();

    private void Awake()
    {
        applyButton.onClick.AddListener(OnApply);

        title.text = minigame.name;
        preview.sprite = minigame.Preview;

        int win = RandomizeStat(minigame.PossibleWin, 6);
        int lose = RandomizeStat(minigame.PossibleLost, 3);
        int time = RandomizeStat(minigame.TimeSpend, 1);

        possibleWin.text = "Win: "+ win.ToString();
        possibleLost.text = "Lose" + lose.ToString();
        timeSpend.text = "Time" + time.ToString();

        tempArenaInfo.moneyWin = win;
        tempArenaInfo.moneyLoss = lose;
        tempArenaInfo.timeLoss = time;
        tempArenaInfo.sceneEnum = minigame.SceneEnum;
    }

    public void OnApply()
    {
        if (tempArenaInfo != null)
        {
            DayManagement.Instance.SetArenaInformation(tempArenaInfo);
        }
    }

    private int RandomizeStat(int stat, int variation)
    {
        int newValue = (stat += Random.Range(-variation, variation));
        newValue = newValue < 0 ? 0 : newValue;
        return newValue;
    }
}
