using System;
using TMPro;
using UnityEngine;

/// <summary>
/// The MetaGameplayManager class manages the overall gameplay meta information, such as money, time cycles, and UI.
/// </summary>
public class MetaGameplayManager : Singleton<MetaGameplayManager>
{
    [Header("Money")]
    [SerializeField] int startMoneyMin;
    [SerializeField] int startMoneyMax;

    [Header("Timers")]
    [SerializeField] private int limitDays;
    [SerializeField] private int timePerDay;

    [Header("UI")]
    [SerializeField] GameObject persistenUI;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text dayText;

    /// <summary>
    /// Gets the MoneyHolder, which manages the in-game currency.
    /// </summary>
    public MoneyHolder MoneyHolder => moneyHolder;
    private MoneyHolder moneyHolder;

    /// <summary>
    /// Gets the CycleManager, which manages the day-night cycles and game progression.
    /// </summary>
    public CycleManager CycleManager => cycleManager;
    private CycleManager cycleManager;

    /// <summary>
    /// Initializes the MetaGameplayManager by setting up the initial money and time cycle.
    /// </summary>
    private void Start()
    {
        moneyHolder = new MoneyHolder(startMoneyMin, startMoneyMax);
        cycleManager = new CycleManager(limitDays, timePerDay);

        cycleManager.OnCycleEnded += EndGame;

        SceneManager.Instance.OnSceneChanged += UpdateDayDisplay;
        SceneManager.Instance.OnSceneChanged += UpdateMoneyDisplay;

        UpdateDayDisplay();
        UpdateMoneyDisplay();
    }

    /// <summary>
    /// Sets the visibility of the persistent UI.
    /// </summary>
    /// <param name="active">True to make the UI visible, false to hide it.</param>
    public void SetActivePersistentUI(bool active)
    {
        persistenUI.SetActive(active);
    }

    /// <summary>
    /// Handles the end of the game.
    /// </summary>
    private void EndGame()
    {
        // Add any logic for ending the game here
    }

    /// <summary>
    /// Moves to the next time cycle.
    /// </summary>
    public void NextCycle()
    {
        cycleManager.GoToNextCycle();
    }

    /// <summary>
    /// Updates the display of the current day and cycle type in the UI.
    /// </summary>
    private void UpdateDayDisplay()
    {
        string dayIndex = cycleManager.CurrentDay.ToString();
        string cycleType = cycleManager.IsDay ? "Day" : "Night";
        dayText.text = $"Day {dayIndex} - {cycleType}";
    }

    /// <summary>
    /// Updates the display of the in-game money in the UI.
    /// </summary>
    private void UpdateMoneyDisplay()
    {
        string moneyString = moneyHolder.Money.ToString();
        moneyText.text = $"{moneyString} caps";
    }
}