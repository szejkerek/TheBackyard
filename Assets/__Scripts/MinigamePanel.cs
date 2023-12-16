using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a panel displaying information about a mini-game and allows applying its settings.
/// </summary>
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

    /// <summary>
    /// Temporary storage for arena information before applying.
    /// </summary>
    ArenaInformation tempArenaInfo = new ArenaInformation();

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        applyButton.onClick.AddListener(OnApply);
        title.text = minigame.MinigameName;
        preview.sprite = minigame.Preview;

        int win = RandomizeStat(minigame.PossibleWin, 6);
        int lose = RandomizeStat(minigame.PossibleLost, 3);
        int time = RandomizeStat(minigame.TimeSpend, 1);

        possibleWin.text = "Win: " + win.ToString();
        possibleLost.text = "Lose: " + lose.ToString();
        timeSpend.text = "Time: " + time.ToString();

        tempArenaInfo.moneyWin = win;
        tempArenaInfo.moneyLoss = lose;
        tempArenaInfo.timeLoss = time;
        tempArenaInfo.sceneEnum = minigame.SceneEnum;
    }

    /// <summary>
    /// Applies the selected mini-game settings to the game.
    /// </summary>
    public void OnApply()
    {
        if (tempArenaInfo != null)
        {
            DayManagement.Instance.SetArenaInformation(tempArenaInfo);
        }
    }

    /// <summary>
    /// Randomizes a stat value with the given variation.
    /// </summary>
    /// <param name="stat">The base stat value.</param>
    /// <param name="variation">The range of variation for the stat.</param>
    /// <returns>The randomized stat value.</returns>
    private int RandomizeStat(int stat, int variation)
    {
        int newValue = (stat += Random.Range(-variation, variation));
        newValue = newValue < 0 ? 0 : newValue;
        return newValue;
    }
}
