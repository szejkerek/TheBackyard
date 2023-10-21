using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public CharacterStats stats = new CharacterStats();
}

public class CharacterStats
{
    public float stamina = 5;

    public void RandomizeStats()
    {
        throw new NotImplementedException();
    }
}