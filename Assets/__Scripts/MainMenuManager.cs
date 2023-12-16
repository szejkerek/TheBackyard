using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the main menu interactions and transitions.
/// </summary>
public class MainMenuManager : Singleton<MainMenuManager>
{
    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.MenuKids);
    }

    /// <summary>
    /// Loads the character selection scene.
    /// </summary>
    public void LoadCharacterSelection()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        SceneManager.Instance.LoadScene(SceneEnum.CharacterSelection);
    }

    /// <summary>
    /// Loads the credits scene.
    /// </summary>
    public void LoadCredits()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);

        SceneManager.Instance.LoadScene(SceneEnum.Credits);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        Application.Quit();
    }
}