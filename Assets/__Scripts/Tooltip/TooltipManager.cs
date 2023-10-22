using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : Singleton<TooltipManager>
{
    public Tooltip tooltip;
    public float delay = 0.5f;

    private Coroutine showCoroutine;
    public void Show(string content, string header = "")
    {
        showCoroutine = StartCoroutine(ShowWithDelay(content, header));
    }

    public void Hide() 
    {
        if (showCoroutine != null)
        {
            StopCoroutine(showCoroutine);
        }
        tooltip.gameObject.SetActive(false);
    }

    private IEnumerator ShowWithDelay(string content, string header)
    {
        yield return new WaitForSeconds(delay);
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }
}
