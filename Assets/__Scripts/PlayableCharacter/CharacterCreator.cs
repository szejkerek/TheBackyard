using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public CharacterInfo CharacterInfo => characterInfo;
    CharacterInfo characterInfo;
    CharacterAppearanceCreator characterAppearanceCreator;

    private void Awake()
    {
        characterAppearanceCreator = GetComponentInChildren<CharacterAppearanceCreator>();
    }

    public void Create(CharacterInfo characterInfo)
    {
        this.characterInfo = characterInfo;
        characterAppearanceCreator.GenerateCharacterAppearance(characterInfo.customSet);
    }

    public void CreateRandom()
    {
        CustomModularSet customSet = characterAppearanceCreator.RandomizeSet();   
        CharacterStats stats = new CharacterStats();
        stats.RandomizeStats();
        CharacterInfo characterInfo = new CharacterInfo(stats, customSet);
        this.characterInfo = characterInfo;
        characterAppearanceCreator.GenerateCharacterAppearance(characterInfo.customSet);
    }
}
