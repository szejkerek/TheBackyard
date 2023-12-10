using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the upgrading of character information, including speed and agility.
/// </summary>
public class UpgradeCharacterManager : Singleton<UpgradeCharacterManager>
{
    /// <summary>
    /// The list of character information for upgrade.
    /// </summary>
    public List<CharacterInfo> charactersInfo;

    /// <summary>
    /// The list of UI elements displaying character texts and costs.
    /// </summary>
    public List<CharacterTexts> characterTexts;

    /// <summary>
    /// The list of panels displaying teammate information.
    /// </summary>
    [SerializeField] private List<GameObject> teammatePanels;

    /// <summary>
    /// The incremental cost for upgrading capsell (speed/agility).
    /// </summary>
    [SerializeField] private int capsellCostIncrement = 5;

    /// <summary>
    /// The base cost for upgrading capsell (speed/agility).
    /// </summary>
    [SerializeField] private int baseCapsellCost = 5;

    /// <summary>
    /// Updates the character information, including capsell (speed/agility) upgrades.
    /// </summary>
    /// <param name="characterInfo">The character to be updated.</param>
    /// <param name="updateSpeed">True if updating speed; False if updating agility.</param>
    public void UpdateCharacterInfo(CharacterInfo characterInfo, bool updateSpeed)
    {
        var index = charactersInfo.IndexOf(characterInfo);
        charactersInfo[index] = characterInfo;

        if (updateSpeed)
        {
            if (MetaGameplayManager.Instance.MoneyHolder.Money > characterTexts[index].capsellSpeedCost)
            {
                characterTexts[index].capsellSpeedCost += capsellCostIncrement;
                characterTexts[index].characterSpeed.text = $"Speed: {characterTexts[index].characterInfo.stats.speed}";
                characterTexts[index].characterSpeedCost.text = $"Cost: {characterTexts[index].capsellSpeedCost}";
                MetaGameplayManager.Instance.MoneyHolder.RemoveMoney(characterTexts[index].capsellSpeedCost);
                Debug.Log($"Removed {characterTexts[index].capsellSpeedCost} money");
            }
        }
        else
        {
            if (MetaGameplayManager.Instance.MoneyHolder.Money > characterTexts[index].capsellAgilityCost)
            {
                characterTexts[index].capsellAgilityCost += capsellCostIncrement;
                characterTexts[index].characterAgility.text = $"Agility: {characterTexts[index].characterInfo.stats.agility}";
                characterTexts[index].characterAgilityCost.text = $"Cost: {characterTexts[index].capsellAgilityCost}";
                MetaGameplayManager.Instance.MoneyHolder.RemoveMoney(characterTexts[index].capsellAgilityCost);
                Debug.Log($"Removed {characterTexts[index].capsellAgilityCost} money");
            }
        }
    }

    private void Start()
    {
        charactersInfo = GameManager.Instance.PlayableCharacters;
        for (int i = 0; i < charactersInfo.Count; i++)
        {
            characterTexts[i].characterInfo = charactersInfo[i];
            characterTexts[i].capsellAgilityCost = baseCapsellCost;
            characterTexts[i].capsellSpeedCost = baseCapsellCost;
        }
    }

    /// <summary>
    /// Represents the UI elements displaying character texts and costs.
    /// </summary>
    [System.Serializable]
    public class CharacterTexts
    {
        /// <summary>
        /// The character information associated with the UI elements.
        /// </summary>
        public CharacterInfo characterInfo;

        /// <summary>
        /// The current cost for upgrading capsell (agility).
        /// </summary>
        public int capsellAgilityCost;

        /// <summary>
        /// The current cost for upgrading capsell (speed).
        /// </summary>
        public int capsellSpeedCost;

        /// <summary>
        /// The UI element displaying character agility.
        /// </summary>
        public TextMeshProUGUI characterAgility;

        /// <summary>
        /// The UI element displaying the cost of upgrading character agility.
        /// </summary>
        public TextMeshProUGUI characterAgilityCost;

        /// <summary>
        /// The UI element displaying character speed.
        /// </summary>
        public TextMeshProUGUI characterSpeed;

        /// <summary>
        /// The UI element displaying the cost of upgrading character speed.
        /// </summary>
        public TextMeshProUGUI characterSpeedCost;
    }
}