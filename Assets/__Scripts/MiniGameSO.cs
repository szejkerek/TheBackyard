using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MinigameSO", menuName = "MinigameSO", order = 1)]
public class MinigameSO : ScriptableObject
{
    [field: SerializeField] public int SceneIndex { private set; get; }
    [field: SerializeField] public Image Preview { private set; get; }
    [field: SerializeField] public string MinigameName { private set; get; }
    [field: SerializeField] public int PotentialWin { private set; get; }
    [field: SerializeField] public int PotentialLose { private set; get; }
    [field: SerializeField] public int TimeSpend { private set; get; }
}