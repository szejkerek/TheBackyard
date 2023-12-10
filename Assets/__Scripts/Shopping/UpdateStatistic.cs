using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates the statistics of a character, either speed or agility.
/// </summary>
public class UpdateStatistic : MonoBehaviour
{
    /// <summary>
    /// Determines whether to update speed or agility.
    /// </summary>
    [SerializeField] private bool updateSpeed = true;

    /// <summary>
    /// The value by which to update the character's speed or agility.
    /// </summary>
    [SerializeField] private float updateValue = 1.0f;

    /// <summary>
    /// The index of the character's statistic to update.
    /// </summary>
    [SerializeField] private int characterStatIndex = 0;

    /// <summary>
    /// Updates the character's speed or agility based on the specified parameters.
    /// </summary>
    public void UpdateCharacterStat()
    {
        var character = UpgradeCharacterManager.Instance.charactersInfo[characterStatIndex];

        if (updateSpeed)
        {
            character.stats.speed += updateValue;
        }
        else
        {
            character.stats.agility += updateValue;
        }

        UpgradeCharacterManager.Instance.UpdateCharacterInfo(character, updateSpeed);
    }
}