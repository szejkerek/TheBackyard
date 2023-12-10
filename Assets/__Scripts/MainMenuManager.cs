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
        // Play the global music for the main menu.
        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.MenuKids);
    }

    /// <summary>
    /// Loads the character selection scene.
    /// </summary>
    public void LoadCharacterSelection()
    {
        // Play a mouse click sound effect.
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);

        // Load the character selection scene.
        SceneManager.Instance.LoadScene(SceneEnum.CharacterSelection);
    }

    /// <summary>
    /// Loads the credits scene.
    /// </summary>
    public void LoadCredits()
    {
        // Play a mouse click sound effect.
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);

        // Load the credits scene.
        SceneManager.Instance.LoadScene(SceneEnum.Credits);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void ExitGame()
    {
        // Play a mouse click sound effect.
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);

        // Exit the application.
        Application.Quit();
    }
}