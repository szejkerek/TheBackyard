using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ModularDataSet modularDataSet;
    [SerializeField] List<CharacterInfo> playableCharactersInfo;

    public ArenaInformation ArenaInformation => arenaInformation;
    ArenaInformation arenaInformation;

    private void Start()
    {
        playableCharactersInfo.Add(new CharacterInfo(modularDataSet));
        playableCharactersInfo.Add(new CharacterInfo(modularDataSet));
        playableCharactersInfo.Add(new CharacterInfo(modularDataSet));
    }

    public void SetArenaInformation(ArenaInformation arenaInformation)
    {
        this.arenaInformation = arenaInformation;
    }

    public void ClearArenaInformation()
    {
        this.arenaInformation = null;
    }
}
