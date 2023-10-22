using System;
using TMPro;
using UnityEngine;

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

    public MoneyHolder MoneyHolder => moneyHolder;
    private MoneyHolder moneyHolder;

    public CycleManager CycleManager => cycleManager;
    private CycleManager cycleManager;

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

    public void SetActivePersistentUI(bool active)
    {
        persistenUI.SetActive(active);
    }

    private void EndGame()
    {
        
    }

    public void NextCycle()
    {
        cycleManager.GoToNextCycle();
    }

    private void UpdateDayDisplay()
    {
        string dayIndex = cycleManager.CurrentDay.ToString();
        string cycleType = cycleManager.IsDay ? "Day" : "Night";
        dayText.text = $"Day {dayIndex} - {cycleType}";
    }

    void UpdateMoneyDisplay()
    {
        string moneyString = moneyHolder.Money.ToString();
        moneyText.text = $"{moneyString} caps";
    }
}
