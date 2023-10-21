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
        DayNightCycleManager.Instance.OnNewCycle += UpdateDayDisplay;
        DayNightCycleManager.Instance.OnCycleEnded += EndGame;

        DayNightCycleManager.Instance.GoToNextCycle();
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
