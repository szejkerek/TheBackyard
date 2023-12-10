using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the visibility of the persistent UI using the MetaGameplayManager.
/// </summary>
public class SetUIActive : MonoBehaviour
{
    /// <summary>
    /// Flag indicating whether the UI should be visible or not.
    /// </summary>
    public bool visibleUI;

    /// <summary>
    /// Sets the visibility of the persistent UI during the Start phase.
    /// </summary>
    void Start()
    {
        MetaGameplayManager.Instance.SetActivePersistentUI(visibleUI);
    }
}