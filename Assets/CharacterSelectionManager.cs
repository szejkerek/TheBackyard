using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterSelectionManager : Singleton<CharacterSelectionManager>
{
    [SerializeField] CharacterCreator first;
    [SerializeField] CharacterCreator sencond;
    [SerializeField] CharacterCreator third;

    private void Start()
    {
        AssignCharacterInfo(first, 0, randomize: true);
        AssignCharacterInfo(sencond, 1, randomize: true);
        AssignCharacterInfo(third, 2, randomize: true);
    }

    public void RandomizeFirst()
    {
        AssignCharacterInfo(first, 0, randomize: true);
    }

    public void RandomizeSencond()
    {
        AssignCharacterInfo(sencond, 1, randomize: true);
    }

    public void RandomizeThird()
    {
        AssignCharacterInfo(third, 2, randomize: true);
    }
    public void LoadGame()
    {
        AssignCharacterInfo(first, 0, randomize: false);
        AssignCharacterInfo(sencond, 1, randomize: false);
        AssignCharacterInfo(third, 2, randomize: false);
        SceneManager.Instance.LoadScene(SceneEnum.NightManagementScene);
    }

    private void AssignCharacterInfo(CharacterCreator creator, int index, bool randomize)
    {
        if(randomize) 
        {
            creator.CreateRandom();
        }
        
        CharacterInfo character = creator.CharacterInfo;
        GameManager.Instance.PlayableCharacters[index] = character;
    }
}
