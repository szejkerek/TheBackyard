using System;

public class MoneyHolder
{
    public Action OnMoneyChange;

    int startMoneyMin;
    int startMoneyMax;

    public int Money => money;
    int money = 0;

    public MoneyHolder(int startMoneyMin = 20, int startMoneyMax = 70)
    {
        this.startMoneyMin = startMoneyMin;
        this.startMoneyMax = startMoneyMax;
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
