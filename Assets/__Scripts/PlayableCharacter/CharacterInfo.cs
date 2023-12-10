using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Represents the information associated with a character, including their stats and custom modular set for appearance.
/// </summary>
[System.Serializable]
public class CharacterInfo
{
    /// <summary>
    /// The stats of the character.
    /// </summary>
    public CharacterStats stats;

    /// <summary>
    /// The custom modular set defining the appearance of the character.
    /// </summary>
    public CustomModularSet customSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterInfo"/> class with the specified <paramref name="stats"/> and <paramref name="customSet"/>.
    /// </summary>
    /// <param name="stats">The character stats.</param>
    /// <param name="customSet">The custom modular set for appearance.</param>
    public CharacterInfo(CharacterStats stats, CustomModularSet customSet)
    {
        this.stats = stats;
        this.customSet = customSet;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CharacterInfo"/> class with default stats and a random custom modular set.
    /// </summary>
    public CharacterInfo()
    {
        stats = new CharacterStats();
        customSet = new CustomModularSet();
    }
}

/// <summary>
/// Represents the stats of a character, including agility and speed.
/// </summary>
[System.Serializable]
public class CharacterStats
{
    /// <summary>
    /// The agility stat of the character.
    /// </summary>
    public float agility = 5;

    /// <summary>
    /// The speed stat of the character.
    /// </summary>
    public float speed = 5;

    /// <summary>
    /// Randomizes the agility and speed stats within a specified range.
    /// </summary>
    public void RandomizeStats()
    {
        agility = Random.Range(0.1f, 1f);
        speed = Random.Range(0.1f, 1f);
    }
}