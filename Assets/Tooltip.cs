using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layout;
    public int characterWrap;

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
}
