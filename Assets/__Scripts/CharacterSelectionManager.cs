using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages character selection in the game.
/// </summary>
public class CharacterSelectionManager : Singleton<CharacterSelectionManager>
{
    [SerializeField] CharacterCreator first;
    [SerializeField] CharacterCreator sencond;
    [SerializeField] CharacterCreator third;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        // Initialize character information for the first, second, and third characters.
        AssignCharacterInfo(first, 0, randomize: true);
        AssignCharacterInfo(sencond, 1, randomize: true);
        AssignCharacterInfo(third, 2, randomize: true);
    }

    /// <summary>
    /// Randomizes the information for the first character.
    /// </summary>
    public void RandomizeFirst()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        AssignCharacterInfo(first, 0, randomize: true);
    }

    /// <summary>
    /// Randomizes the information for the second character.
    /// </summary>
    public void RandomizeSencond()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        AssignCharacterInfo(sencond, 1, randomize: true);
    }

    /// <summary>
    /// Randomizes the information for the third character.
    /// </summary>
    public void RandomizeThird()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        AssignCharacterInfo(third, 2, randomize: true);
    }

    /// <summary>
    /// Loads the game scene with the selected characters.
    /// </summary>
    public void LoadGame()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);

        // Assign the selected character information without randomization.
        AssignCharacterInfo(first, 0, randomize: false);
        AssignCharacterInfo(sencond, 1, randomize: false);
        AssignCharacterInfo(third, 2, randomize: false);

        // Load the Night Management scene.
        SceneManager.Instance.LoadScene(SceneEnum.NightManagementScene);
    }

    /// <summary>
    /// Assigns character information to the specified character creator.
    /// </summary>
    /// <param name="creator">The character creator to assign information to.</param>
    /// <param name="index">The index representing the character's position.</param>
    /// <param name="randomize">Whether to randomize the character information.</param>
    private void AssignCharacterInfo(CharacterCreator creator, int index, bool randomize)
    {
        if (randomize)
        {
            // Randomize the character information.
            creator.CreateRandom();
        }

        // Retrieve the character information from the creator and assign it to the GameManager.
        CharacterInfo character = creator.CharacterInfo;
        GameManager.Instance.PlayableCharacters[index] = character;
    }
}
