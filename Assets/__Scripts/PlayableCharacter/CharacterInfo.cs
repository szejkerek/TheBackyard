using System;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    public CharacterStats stats;
    public CustomModularSet customSet;

    public CharacterInfo(CharacterStats stats, CustomModularSet customSet)
    {
        this.stats = stats;
        this.customSet = customSet;
    }

    public CharacterInfo()
    {
        stats = new CharacterStats();
        customSet = new CustomModularSet();

    }
}

[System.Serializable]
public class CharacterStats
{
    public float stamina = 5;

    public void RandomizeStats()
    {
        throw new NotImplementedException();
    }
}