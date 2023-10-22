using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUIActive : MonoBehaviour
{
    public bool visibleUI;
    void Start()
    {
        MetaGameplayManager.Instance.SetActivePersistentUI(visibleUI);
    }
}
