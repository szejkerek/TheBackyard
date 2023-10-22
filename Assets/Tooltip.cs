using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layout;
    public int characterWrap;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
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

    private void SetSize()
    {
        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layout.enabled = (headerLenght > characterWrap || contentLenght > characterWrap) ? true : false;
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;
        float x = position.x / Screen.width;
        float y = position.y / Screen.height;
        if (x <= y && x <= 1 - y) //left
            rectTransform.pivot = new Vector2(-0.15f, y);
        else if (x >= y && x <= 1 - y) //bottom
            rectTransform.pivot = new Vector2(x, -0.1f);
        else if (x >= y && x >= 1 - y) //right
            rectTransform.pivot = new Vector2(1.1f, y);
        else if (x <= y && x >= 1 - y) //top
            rectTransform.pivot = new Vector2(x, 1.3f);
        transform.position = position;
    }

}
