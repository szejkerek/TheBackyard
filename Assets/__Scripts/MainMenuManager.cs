using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    private void Start()
    {
        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.MenuKids);
    }
    public void LoadCharacterSelection()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        SceneManager.Instance.LoadScene(SceneEnum.CharacterSelection);
    }
    public void LoadCredits()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        SceneManager.Instance.LoadScene(SceneEnum.Credits);
    }

    public void ExitGame()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        Application.Quit();
    }
}
