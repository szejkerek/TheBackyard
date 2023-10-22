using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MiniGameSO", menuName = "MiniGameSO", order = 1)]
public class MiniGameSO : ScriptableObject
{
    [field: SerializeField] public int SceneIndex { private set; get; }
    [field: SerializeField] public Sprite Preview { private set; get; }
    [field: SerializeField] public string MinigameName { private set; get; }
    [field: SerializeField] public int PossibleWin { private set; get; }
    [field: SerializeField] public int PossibleLost { private set; get; }
    [field: SerializeField] public int TimeSpend { private set; get; }
}