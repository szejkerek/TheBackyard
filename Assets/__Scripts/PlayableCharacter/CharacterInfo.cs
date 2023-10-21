using System;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    public CharacterStats stats = new CharacterStats();
    public CustomModularSet CustomModularSet = new CustomModularSet();

    public CharacterInfo(ModularDataSet mod)
    {
        CustomModularSet.RandomizeSet(mod);
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