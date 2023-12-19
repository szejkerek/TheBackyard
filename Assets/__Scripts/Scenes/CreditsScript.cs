using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the behavior of the credits screen.
/// </summary>
public class CreditsScript : MonoBehaviour
{
    /// <summary>
    /// Loads the main menu scene when called and plays a mouse click sound.
    /// </summary>
    public void LoadMenu()
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.MouseClick);
        SceneManager.Instance.LoadScene(SceneEnum.MainMenu);
    }
}