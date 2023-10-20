using System;
using TMPro;
using UnityEngine;

public class MetaGameplayManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text dayText;

    private void Start()
    {
        MoneyManager.Instance.OnMoneyChange += UpdateMoneyDisplay;
        DayNightCycleManager.Instance.OnNextDay += UpdateDayDisplay;

        DayNightCycleManager.Instance.GoToNextDay();
    }

    private void UpdateDayDisplay()
    {
        string day = DayNightCycleManager.Instance.CurrentDay.ToString();

        dayText.text = $"{day} day";
    }

    void UpdateMoneyDisplay()
    {
        string moneyString = MoneyManager.Instance.Money.ToString();

        moneyText.text = $"{moneyString} money";
    }
}
