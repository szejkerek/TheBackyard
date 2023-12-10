using System;

/// <summary>
/// Holds and manages the amount of money available to the player.
/// </summary>
public class MoneyHolder
{
    public Action OnMoneyChange;
    public Action OnNoMoneyLeft;

    private int startMoneyMin;
    private int startMoneyMax;

    /// <summary>
    /// Gets the current amount of money.
    /// </summary>
    public int Money => money;
    private int money = 0;

    /// <summary>
    /// Initializes a new instance of the MoneyHolder class with a specified range of starting money.
    /// </summary>
    /// <param name="startMoneyMin">The minimum starting money.</param>
    /// <param name="startMoneyMax">The maximum starting money.</param>
    public MoneyHolder(int startMoneyMin = 20, int startMoneyMax = 70)
    {
        this.startMoneyMin = startMoneyMin;
        this.startMoneyMax = startMoneyMax;
        GenerateStartingMoney();
    }

    /// <summary>
    /// Generates a random amount of starting money within the specified range.
    /// </summary>
    private void GenerateStartingMoney()
    {
        int value = UnityEngine.Random.Range(startMoneyMin, startMoneyMax);
        AddMoney(value);
    }

    /// <summary>
    /// Adds a specified amount of money to the current total.
    /// </summary>
    /// <param name="amount">The amount of money to add.</param>
    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }

        money += amount;
        OnMoneyChange?.Invoke();
    }

    /// <summary>
    /// Removes a specified amount of money from the current total.
    /// </summary>
    /// <param name="amount">The amount of money to remove.</param>
    public void RemoveMoney(int amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }

        money -= amount;

        // Ensure the money total does not go below zero.
        if (money < 0)
        {
            money = 0;
            OnNoMoneyLeft?.Invoke();
        }

        OnMoneyChange?.Invoke();
    }
}
