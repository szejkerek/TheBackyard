using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Provides functionality for a tooltip UI element.
/// </summary>
[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    /// <summary>
    /// Gets or sets the TextMeshProUGUI for the header field in the tooltip.
    /// </summary>
    public TextMeshProUGUI headerField;

    /// <summary>
    /// Gets or sets the TextMeshProUGUI for the content field in the tooltip.
    /// </summary>
    public TextMeshProUGUI contentField;

    /// <summary>
    /// Gets or sets the LayoutElement for controlling the layout of the tooltip.
    /// </summary>
    public LayoutElement layout;

    /// <summary>
    /// Gets or sets the character wrap value for the tooltip.
    /// </summary>
    public int characterWrap;

    /// <summary>
    /// Gets the RectTransform component of the tooltip.
    /// </summary>
    public RectTransform rectTransform;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Sets the text content of the tooltip.
    /// </summary>
    /// <param name="content">The content text to display.</param>
    /// <param name="header">The header text to display (optional).</param>
    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        SetSize();
    }

    /// <summary>
    /// Adjusts the size of the tooltip based on the content length.
    /// </summary>
    private void SetSize()
    {
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layout.enabled = (headerLength > characterWrap || contentLength > characterWrap) ? true : false;
    }

    /// <summary>
    /// Called every frame, updates the position and pivot of the tooltip based on mouse position.
    /// </summary>
    private void Update()
    {
        Vector2 position = Input.mousePosition;
        float x = position.x / Screen.width;
        float y = position.y / Screen.height;
        if (x <= y && x <= 1 - y) // left
            rectTransform.pivot = new Vector2(-0.15f, y);
        else if (x >= y && x <= 1 - y) // bottom
            rectTransform.pivot = new Vector2(x, -0.1f);
        else if (x >= y && x >= 1 - y) // right
            rectTransform.pivot = new Vector2(1.1f, y);
        else if (x <= y && x >= 1 - y) // top
            rectTransform.pivot = new Vector2(x, 1.3f);
        transform.position = position;
    }
}