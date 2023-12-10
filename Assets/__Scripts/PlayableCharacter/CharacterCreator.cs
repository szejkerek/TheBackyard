using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible for creating character instances and managing their appearances.
/// </summary>
public class CharacterCreator : MonoBehaviour
{
    /// <summary>
    /// Determines whether this character should be set as playable.
    /// </summary>
    [SerializeField] bool setAsPlayable = false;

    /// <summary>
    /// Index to specify which playable character to create if set as playable.
    /// </summary>
    [SerializeField] int playableIndex;

    /// <summary>
    /// Gets the character information associated with this character.
    /// </summary>
    public CharacterInfo CharacterInfo => characterInfo;

    /// <summary>
    /// Reference to the character information for this character.
    /// </summary>
    CharacterInfo characterInfo;

    /// <summary>
    /// Reference to the CharacterAppearanceCreator component for managing the character's appearance.
    /// </summary>
    CharacterAppearanceCreator characterAppearanceCreator;

    private void Awake()
    {
        characterAppearanceCreator = GetComponentInChildren<CharacterAppearanceCreator>();

        // Create the character with a specific playable character if set to be playable.
        if (setAsPlayable)
        {
            Create(GameManager.Instance.PlayableCharacters[playableIndex]);
        }
    }

    /// <summary>
    /// Creates a character with the specified <paramref name="characterInfo"/>.
    /// </summary>
    /// <param name="characterInfo">Character information to use for creating the character.</param>
    public void Create(CharacterInfo characterInfo)
    {
        this.characterInfo = characterInfo;
        characterAppearanceCreator.GenerateCharacterAppearance(characterInfo.customSet);
    }

    /// <summary>
    /// Creates a character with random appearance and stats.
    /// </summary>
    public void CreateRandom()
    {
        // Randomize a modular set for appearance and create character information.
        CustomModularSet customSet = characterAppearanceCreator.RandomizeSet();
        CharacterStats stats = new CharacterStats();
        stats.RandomizeStats();
        CharacterInfo characterInfo = new CharacterInfo(stats, customSet);

        // Set the character information and generate the appearance.
        this.characterInfo = characterInfo;
        characterAppearanceCreator.GenerateCharacterAppearance(characterInfo.customSet);
    }
}