using System;
using TMPro;
using UnityEngine;

public class MetaGameplayManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text dayText;
    [SerializeField] TMP_Text endGame;

    private void Start()
    {
        MoneyManager.Instance.OnMoneyChange += UpdateMoneyDisplay;
        SceneManager.Instance.OnSceneChanged += UpdateDayDisplay;
        DayNightCycleManager.Instance.OnCycleEnded += EndGame;
        UpdateDayDisplay();
        UpdateMoneyDisplay();
    }

    private void EndGame()
    {
        endGame.gameObject.SetActive(true);
    }

    private void UpdateDayDisplay()
    {
        string dayIndex = DayNightCycleManager.Instance.CurrentDay.ToString();
        string cycleType = DayNightCycleManager.Instance.IsDay ? "Day" : "Night";
        dayText.text = $"{dayIndex} day - {cycleType}";
    }

    void UpdateMoneyDisplay()
    {
        string moneyString = MoneyManager.Instance.Money.ToString();
        moneyText.text = $"{moneyString} money";
    }
}
