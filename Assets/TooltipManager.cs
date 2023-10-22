using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : Singleton<TooltipManager>
{
    public Tooltip tooltip;
    public void Show(string content, string header = "")
    {
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }

    public void Hide() 
    {
        tooltip.gameObject.SetActive(false);
    }
}
