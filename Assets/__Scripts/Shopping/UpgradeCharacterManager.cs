using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCharacterManager : Singleton<UpgradeCharacterManager>
{
    public List<CharacterInfo> charactersInfo;
    public List<CharacterTexts> characterTexts;

    [SerializeField] private List<GameObject> teammatePanels;
    [SerializeField] private int capsellCostIncrement = 5;
    [SerializeField] private int baseCapsellCost = 5;

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

    [System.Serializable]
    public class CharacterTexts
    {
        public CharacterInfo characterInfo;
        public int capsellAgilityCost;
        public int capsellSpeedCost;
        public TextMeshProUGUI characterAgility;
        public TextMeshProUGUI characterAgilityCost;
        public TextMeshProUGUI characterSpeed;
        public TextMeshProUGUI characterSpeedCost;
    }
}
