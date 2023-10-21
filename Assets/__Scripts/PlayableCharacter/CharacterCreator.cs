using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
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
<<<<<<< HEAD

=======
        CustomModularSet customSet = new CustomModularSet();   
        CharacterStats stats = new CharacterStats();
        
>>>>>>> develop
    }
}
