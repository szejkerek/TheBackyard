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
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text dayText;
    [SerializeField] TMP_Text endGame;

    public MoneyHolder MoneyHolder => moneyHolder;
    private MoneyHolder moneyHolder;

    public CycleManager CycleManager => cycleManager;
    private CycleManager cycleManager;

    private void Start()
    {
        moneyHolder = new MoneyHolder(startMoneyMin, startMoneyMax);
        cycleManager = new CycleManager(limitDays, timePerDay);

        moneyHolder.OnMoneyChange += UpdateMoneyDisplay;
        cycleManager.OnCycleEnded += EndGame;

        SceneManager.Instance.OnSceneChanged += UpdateDayDisplay;
        
        UpdateDayDisplay();
        UpdateMoneyDisplay();
    }

    private void EndGame()
    {
        endGame.gameObject.SetActive(true);
    }

    public void NextCycle()
    {
        cycleManager.GoToNextCycle();
    }

    private void UpdateDayDisplay()
    {
        string dayIndex = cycleManager.CurrentDay.ToString();
        string cycleType = cycleManager.IsDay ? "Day" : "Night";
        dayText.text = $"{dayIndex} day - {cycleType}";
    }

    void UpdateMoneyDisplay()
    {
        string moneyString = moneyHolder.Money.ToString();
        moneyText.text = $"{moneyString} money";
    }
}
