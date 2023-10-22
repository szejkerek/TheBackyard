using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData/MusicLib", fileName = "MusicLib")]
public class MusicLib : ScriptableObject
{
    [field: SerializeField] public AudioClip Credits { private set; get; }
    [field: SerializeField] public AudioClip MenuKids { private set; get; }
    [field: SerializeField] public AudioClip MenuNoKids { private set; get; }
    [field: SerializeField] public AudioClip PlayTag { private set; get; }
    [field: SerializeField] public AudioClip FloorIsLava { private set; get; }
}