using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the skybox of the scene using a specified material.
/// </summary>
public class SetSceneSkybox : MonoBehaviour
{
    /// <summary>
    /// Material representing the skybox.
    /// </summary>
    [Header("Skybox")]
    [SerializeField] Material skybox;

    /// <summary>
    /// Sets the skybox of the scene to the specified material during Awake.
    /// </summary>
    void Awake()
    {
        RenderSettings.skybox = skybox;
    }
}