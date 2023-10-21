using System;
using UnityEngine;

[System.Serializable]
public class PlayableCharacter
{
    public CharacterStats stats = new CharacterStats();
    public PlayableCharacterModularSet PlayableCharacterModularSet = new PlayableCharacterModularSet();

    public PlayableCharacter(ModularDataSet mod)
    {
        //PlayableCharacterModularSet.RandomizeSet(mod);
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