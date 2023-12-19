using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The GameManager class manages game-related data and functionality.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [SerializeField] ModularDataSet modularDataSet;

    /// <summary>
    /// Gets the list of playable characters.
    /// </summary>
    public List<CharacterInfo> PlayableCharacters => playableCharacters;
    [SerializeField] List<CharacterInfo> playableCharacters;

    /// <summary>
    /// Gets the arena information.
    /// </summary>
    public ArenaInformation ArenaInformation => arenaInformation;
    ArenaInformation arenaInformation;

    /// <summary>
    /// Initializes the GameManager by creating and randomizing three playable characters.
    /// </summary>
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

    /// <summary>
    /// Sets the arena information.
    /// </summary>
    /// <param name="arenaInformation">The arena information to be set.</param>
    public void SetArenaInformation(ArenaInformation arenaInformation)
    {
        this.arenaInformation = arenaInformation;
    }
}