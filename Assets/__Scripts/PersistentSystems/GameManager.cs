using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] ModularDataSet modularDataSet;

    public List<CharacterInfo> PlayableCharacters => playableCharacters;
    [SerializeField] List<CharacterInfo> playableCharacters;

    public ArenaInformation ArenaInformation => arenaInformation;
    ArenaInformation arenaInformation;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CharacterInfo info = new CharacterInfo();
            info.stats.RandomizeStats();
            info.customSet.RandomizeSet(modularDataSet);
            playableCharacters.Add(info);
        }
    }

    public void SetArenaInformation(ArenaInformation arenaInformation)
    {
        this.arenaInformation = arenaInformation;
    }
}
