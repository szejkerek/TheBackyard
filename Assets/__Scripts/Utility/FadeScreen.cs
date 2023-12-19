using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages fading in and out of a screen using a CanvasGroup.
/// </summary>
public class FadeScreen : MonoBehaviour
{
    /// <summary>
    /// Gets the duration of the fade effect in seconds.
    /// </summary>
    public float FadeDuration => fadeDuration;

    [SerializeField] float fadeDuration = 2f;
    [SerializeField] bool fadeOnStart;

    private CanvasGroup alphaChanger;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        alphaChanger = GetComponent<CanvasGroup>();

        // Optionally initiate a fade-in on start.
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    /// <summary>
    /// Initiates a fade-in effect.
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
        MetaGameplayManager.Instance.SetActivePersistentUI(false);
    }

    /// <summary>
    /// Initiates a fade-out effect.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
        SceneManager.Instance.OnSceneFullyLoaded?.Invoke();
    }

    /// <summary>
    /// Initiates a custom fade effect between specified alpha values.
    /// </summary>
    /// <param name="alphaIn">The target alpha for fade-in.</param>
    /// <param name="alphaOut">The target alpha for fade-out.</param>
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    /// <summary>
    /// Coroutine for gradually changing the alpha of the CanvasGroup.
    /// </summary>
    /// <param name="alphaIn">The target alpha for fade-in.</param>
    /// <param name="alphaOut">The target alpha for fade-out.</param>
    /// <returns></returns>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            alphaChanger.alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        alphaChanger.alpha = alphaOut;
    }
}