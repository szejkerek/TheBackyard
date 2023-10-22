using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStatistic : MonoBehaviour
{
    [SerializeField] private bool updateSpeed = true;
    [SerializeField] private float updateValue = 1.0f;
    [SerializeField] private int characterStatIndex = 0;

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
