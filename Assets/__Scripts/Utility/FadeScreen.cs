using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public float FadeDuration => fadeDuration;
    [SerializeField] float fadeDuration = 2f;

    [SerializeField] bool fadeOnStart;

    CanvasGroup alphaChanger;

    private void Awake()
    {
        alphaChanger = GetComponent<CanvasGroup>();
        if(fadeOnStart) 
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
        SceneManager.Instance.OnSceneFullyLoaded?.Invoke();
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;
        while(timer < fadeDuration)
        {
            alphaChanger.alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        alphaChanger.alpha = alphaOut;
    }
}
