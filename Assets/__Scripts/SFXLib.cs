using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject containing a library of sound effects (SFX).
/// </summary>
[CreateAssetMenu(menuName = "AudioData/SFXLib", fileName = "SFXLib")]
public class SFXLib : ScriptableObject
{
    [field: SerializeField] public AudioClip Test { private set; get; }
    [field: SerializeField] public AudioClip MouseClick { private set; get; }
    [field: SerializeField] public AudioClip Click1 { private set; get; }
    [field: SerializeField] public AudioClip Click2 { private set; get; }
    [field: SerializeField] public AudioClip SizzleOnce { private set; get; }
    [field: SerializeField] public AudioClip SizzleLong { private set; get; }
    [field: SerializeField] public AudioClip Win { private set; get; }
    [field: SerializeField] public AudioClip Lose { private set; get; }
}
