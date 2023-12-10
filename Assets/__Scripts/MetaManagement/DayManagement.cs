using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages activities during the day, such as selecting characters and entering arenas.
/// </summary>
public class DayManagement : Singleton<DayManagement>
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject minigamePicker;
    [SerializeField] GameObject characterPicker;

    private CycleManager cycleManager;
    private ArenaInformation arenaInformation;

    private void Start()
    {
        // Initialize references and set up the UI.
        characterPicker.gameObject.SetActive(false);
        cycleManager = MetaGameplayManager.Instance.CycleManager;
        timeText.text = $"Time left: {cycleManager.HoursLeft}h";
        MetaGameplayManager.Instance.SetActivePersistentUI(true);
    }

    /// <summary>
    /// Initiates entry into an arena based on the selected character.
    /// </summary>
    /// <param name="characterIndex">The index of the selected character.</param>
    public void GoIntoArena(int characterIndex)
    {
        if (arenaInformation == null)
        {
            Debug.LogWarning($"Arena information is null");
            return;
        }

        // Set the selected character and initiate the arena scene loading.
        arenaInformation.character = GameManager.Instance.PlayableCharacters[characterIndex];
        GameManager.Instance.SetArenaInformation(arenaInformation);
        SceneManager.Instance.LoadScene(arenaInformation.sceneEnum);
    }

    /// <summary>
    /// Sets the information for the upcoming arena and prepares for character selection.
    /// </summary>
    /// <param name="newArenaInformation">The new arena information.</param>
    public void SetArenaInformation(ArenaInformation newArenaInformation)
    {
        int hoursLeft = MetaGameplayManager.Instance.CycleManager.HoursLeft;
        arenaInformation = newArenaInformation;

        // Check if there is enough time left to enter the selected arena.
        if (arenaInformation.timeLoss >= hoursLeft)
        {
            Debug.LogWarning($"Cannot Go to this arena with {hoursLeft} hours left");
            return;
        }

        // Update UI and enable character selection.
        minigamePicker.gameObject.SetActive(false);
        characterPicker.gameObject.SetActive(true);
    }
}
