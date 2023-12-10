using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the display and hiding of tooltips in the game.
/// </summary>
public class TooltipManager : Singleton<TooltipManager>
{
    /// <summary>
    /// Gets or sets the Tooltip component used for displaying tooltips.
    /// </summary>
    public Tooltip tooltip;

    /// <summary>
    /// Gets or sets the delay before showing the tooltip.
    /// </summary>
    public float delay = 0.5f;

    private Coroutine showCoroutine;

    /// <summary>
    /// Shows a tooltip with the specified content and header text.
    /// </summary>
    /// <param name="content">The content text of the tooltip.</param>
    /// <param name="header">The header text of the tooltip (optional).</param>
    public void Show(string content, string header = "")
    {
        showCoroutine = StartCoroutine(ShowWithDelay(content, header));
    }

    /// <summary>
    /// Hides the currently displayed tooltip.
    /// </summary>
    public void Hide()
    {
        if (showCoroutine != null)
        {
            StopCoroutine(showCoroutine);
        }
        tooltip.gameObject.SetActive(false);
    }

    /// <summary>
    /// Coroutine to show the tooltip with a delay.
    /// </summary>
    /// <param name="content">The content text of the tooltip.</param>
    /// <param name="header">The header text of the tooltip (optional).</param>
    /// <returns>Yield instruction for waiting.</returns>
    private IEnumerator ShowWithDelay(string content, string header)
    {
        yield return new WaitForSeconds(delay);
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }
}