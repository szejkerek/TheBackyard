using System;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    public Action OnMoneyChange;

    [SerializeField] int startMoneyMin = 20;
    [SerializeField] int startMoneyMax = 70;


    public int Money => money;
    int money = 0;

    private void Start()
    {
        GenerateStartingMoney();
    }

    private void GenerateStartingMoney()
    {
        int value = UnityEngine.Random.Range(startMoneyMin, startMoneyMax); 
        AddMoney(value);
    }

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }

        money += amount;
        OnMoneyChange?.Invoke();
    }

    public void RemoveMoney(int amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }
        money -= amount;
        if(money < 0) money = 0;
        OnMoneyChange?.Invoke();
    }
}
