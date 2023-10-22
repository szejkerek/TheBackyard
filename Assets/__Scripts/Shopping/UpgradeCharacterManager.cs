using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCharacterManager : Singleton<UpgradeCharacterManager>
{
    public List<CharacterInfo> charactersInfo;

    [SerializeField] private List<GameObject> teammatePanels;
    [SerializeField] private List<CharacterInfoText> charactersText;

    public void UpdateCharacterInfo(CharacterInfo characterInfo)
    {
        var index = charactersInfo.IndexOf(characterInfo);
        charactersInfo[index] = characterInfo;
        //var updatedList = new List<string>();
        //charactersText[index].texts =
    }

    private void Start()
    {
        charactersInfo = GameManager.Instance.PlayableCharacters;

        var panelParent = GameObject.Find("Team");
        
        for(int i = 0; i < panelParent.transform.childCount; i++)
        {
            var child = panelParent.transform.GetChild(i);
            if (child.name.StartsWith("Teammate"))
            {
                teammatePanels.Add(child.gameObject);
            }
        }

        foreach (var info in charactersInfo)
        {
            var textsList = new List<TextMeshProUGUI>();

            foreach (var teammate in teammatePanels)
            {
                var text = teammate.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                textsList.Add(text); // Teammate01.Teammate.Agility.Vertical.Image.CostTxt
                Debug.Log($"Found {text.text}");
            }

            charactersText.Add(new CharacterInfoText
            {
                textInfo = info,
                texts = textsList
            });
        }

    }
}

public class CharacterInfoText
{
    public CharacterInfo textInfo;
    public List<TextMeshProUGUI> texts;
}
