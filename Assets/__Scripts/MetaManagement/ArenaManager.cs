using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Singleton class managing the arena, handling initialization, character assignment, and win/lose outcomes.
/// </summary>
public class ArenaManager : Singleton<ArenaManager>
{
    /// <summary>
    /// The current information about the arena, including rewards/punishments.
    /// </summary>
    ArenaInformation currentInfo;

    /// <summary>
    /// Initializes the arena manager by getting the current arena information and assigning character attributes.
    /// </summary>
    private void Start()
    {
        // Get the current arena information from the game manager.
        currentInfo = GameManager.Instance.ArenaInformation;

        // If current information is not available, generate debug information.
        if (currentInfo == null)
        {
            Debug.LogError("Couldn't get arena information!");
            currentInfo = DebugArenaInfo();
        }

        // Assign attributes to characters in the arena.
        AssignCharactersAttributes();
    }

    /// <summary>
    /// Assigns attributes to characters in the arena, including randomizing the attributes for AI characters and setting the player's attributes.
    /// </summary>
    private void AssignCharactersAttributes()
    {
        // Find all character creators in the scene.
        List<CharacterCreator> characterList = FindObjectsOfType<CharacterCreator>().ToList();

        // Randomize attributes for AI characters.
        foreach (CharacterCreator character in characterList)
        {
            character.CreateRandom();
        }

        // Set the attributes for the player character.
        CharacterCreator player = FindObjectOfType<PlayerMovement>().GetComponent<CharacterCreator>();
        player.Create(currentInfo.character);
    }

    /// <summary>
    /// Handles the win outcome of the arena, updating the money and time accordingly, and transitioning to the day management scene.
    /// </summary>
    public void WinArena()
    {
        MetaGameplayManager meta = MetaGameplayManager.Instance;
        meta.MoneyHolder.AddMoney(currentInfo.moneyWin);
        meta.CycleManager.DecrementHours(currentInfo.timeLoss);
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    /// <summary>
    /// Handles the lose outcome of the arena, updating the money and time accordingly, and transitioning to the day management scene.
    /// </summary>
    public void LoseArena()
    {
        MetaGameplayManager meta = MetaGameplayManager.Instance;
        meta.MoneyHolder.RemoveMoney(currentInfo.moneyLoss);
        meta.CycleManager.DecrementHours(currentInfo.timeLoss);
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    /// <summary>
    /// Generates debug arena information when the actual information is not available.
    /// </summary>
    /// <returns>Debug arena information with zero rewards and punishments.</returns>
    private ArenaInformation DebugArenaInfo()
    {
        Debug.Log("Generating debug arena info...");
        ArenaInformation info = new ArenaInformation();
        info.moneyWin = 0;
        info.moneyLoss = 0;
        info.timeLoss = 0;
        return info;
    }
}
