using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ModularDataSet modularDataSet;
    [SerializeField] List<PlayableCharacter> playableCharactersInfo;

    private void Start()
    {
        playableCharactersInfo.Add(new PlayableCharacter(modularDataSet));
        playableCharactersInfo.Add(new PlayableCharacter(modularDataSet));
        playableCharactersInfo.Add(new PlayableCharacter(modularDataSet));
    }
}
