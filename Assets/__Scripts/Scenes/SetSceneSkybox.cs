using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneSkybox : MonoBehaviour
{
    [Header("Skybox")]
    [SerializeField] Material skybox;

    void Awake()
    {
        RenderSettings.skybox = skybox;
    }
}
