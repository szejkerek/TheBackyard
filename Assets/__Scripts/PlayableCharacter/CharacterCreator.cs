using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] bool setPlayer = false;
    [SerializeField] int playableIndex = 0;
    CharacterInfo characterInfo;
    CharacterAppearanceCreator characterAppearanceCreator;

    private void Start()
    {
        characterAppearanceCreator = GetComponentInChildren<CharacterAppearanceCreator>();

        if (!setPlayer)
        {
            CreateRandom();
        }
        else
        {
            if(playableIndex >= 0 && playableIndex < 3) 
            { 
                Create(GameManager.Instance.PlayableCharacters[playableIndex]); 
            }          
        }
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
