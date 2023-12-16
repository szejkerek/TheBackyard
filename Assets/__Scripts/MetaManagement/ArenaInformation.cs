using UnityEngine;

/// <summary>
/// Serializable class representing information about an arena, including the associated character, scene, and rewards/punishments.
/// </summary>
[System.Serializable]
public class ArenaInformation
{
    /// <summary>
    /// The character associated with the arena.
    /// </summary>
    public CharacterInfo character;

    /// <summary>
    /// The SceneEnum associated with the arena.
    /// </summary>
    public SceneEnum sceneEnum;

    /// <summary>
    /// The amount of money rewarded when winning in this arena.
    /// </summary>
    public int moneyWin;

    /// <summary>
    /// The amount of money penalized when losing in this arena.
    /// </summary>
    public int moneyLoss;

    /// <summary>
    /// The amount of time penalized when losing in this arena.
    /// </summary>
    public int timeLoss;
}