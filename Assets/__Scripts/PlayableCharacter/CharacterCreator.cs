using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    CharacterInfo characterInfo;
    CharacterAppearanceCreator characterAppearanceCreator;

    private void Awake()
    {
        characterAppearanceCreator.GetComponentInChildren<CharacterAppearanceCreator>();
    }


}
