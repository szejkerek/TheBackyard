using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Triggers the display of a tooltip when the mouse pointer enters the UI element
/// and hides the tooltip when the mouse pointer exits.
/// </summary>
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Gets or sets the header text for the tooltip.
    /// </summary>
    [SerializeField] private string header;

    /// <summary>
    /// Gets or sets the content text for the tooltip.
    /// </summary>
    [SerializeField, TextArea(3, 1)] private string content;

    /// <summary>
    /// Called when the mouse pointer enters the UI element.
    /// Displays the tooltip with the specified content and header.
    /// </summary>
    /// <param name="eventData">The pointer event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(content, header);
    }

    /// <summary>
    /// Called when the mouse pointer exits the UI element.
    /// Hides the displayed tooltip.
    /// </summary>
    /// <param name="eventData">The pointer event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}