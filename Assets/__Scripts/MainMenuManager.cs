using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    public void LoadCharacterSelection()
    {
        SceneManager.Instance.LoadScene(SceneEnum.CharacterSelection);
    }
    public void LoadCredits()
    {
        SceneManager.Instance.LoadScene(SceneEnum.Credits);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
