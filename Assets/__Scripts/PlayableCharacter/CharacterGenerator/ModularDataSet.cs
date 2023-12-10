using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject representing a dataset for modular character customization.
/// </summary>
[CreateAssetMenu(fileName = "ModularDataSet", menuName = "ModularDataSet")]
public class ModularDataSet : ScriptableObject
{
    /// <summary>
    /// List of skin colors.
    /// </summary>
    [field: SerializeField] public List<Color> SkinColor { private set; get; }

    /// <summary>
    /// List of hair colors.
    /// </summary>
    [field: SerializeField] public List<Color> HairColor { private set; get; }

    /// <summary>
    /// List of shoe colors.
    /// </summary>
    [field: SerializeField] public List<Color> ShoeColor { private set; get; }

    /// <summary>
    /// List of body sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Body { private set; get; }

    /// <summary>
    /// List of hair sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Hair { private set; get; }

    /// <summary>
    /// List of eyebrow sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Brows { private set; get; }

    /// <summary>
    /// List of mouth sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Mouth { private set; get; }

    /// <summary>
    /// List of eye sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Eyes { private set; get; }

    /// <summary>
    /// List of nose sprites.
    /// </summary>
    [field: SerializeField] public List<Sprite> Nose { private set; get; }
}

/// <summary>
/// Represents a specific combination of modular elements for character customization.
/// </summary>
[System.Serializable]
public class CustomModularSet
{
    /// <summary>
    /// Skin color for the character.
    /// </summary>
    public Color SkinColor;

    /// <summary>
    /// Hair color for the character.
    /// </summary>
    public Color HairColor;

    /// <summary>
    /// Shoe color for the character.
    /// </summary>
    public Color ShoeColor;

    /// <summary>
    /// Body sprite for the character.
    /// </summary>
    public Sprite Body;

    /// <summary>
    /// Hair sprite for the character.
    /// </summary>
    public Sprite Hair;

    /// <summary>
    /// Eyebrow sprite for the character.
    /// </summary>
    public Sprite Brows;

    /// <summary>
    /// Mouth sprite for the character.
    /// </summary>
    public Sprite Mouth;

    /// <summary>
    /// Eye sprite for the character.
    /// </summary>
    public Sprite Eyes;

    /// <summary>
    /// Nose sprite for the character.
    /// </summary>
    public Sprite Nose;

    /// <summary>
    /// Randomizes the set based on the provided <paramref name="modularDataSet"/>.
    /// </summary>
    /// <param name="modularDataSet">The dataset to use for randomization.</param>
    public void RandomizeSet(ModularDataSet modularDataSet)
    {
        SkinColor = modularDataSet.SkinColor.GetRandomElement();
        HairColor = modularDataSet.HairColor.GetRandomElement();
        ShoeColor = modularDataSet.ShoeColor.GetRandomElement();
        Body = modularDataSet.Body.GetRandomElement();
        Hair = modularDataSet.Hair.GetRandomElement();
        Brows = modularDataSet.Brows.GetRandomElement();
        Mouth = modularDataSet.Mouth.GetRandomElement();
        Eyes = modularDataSet.Eyes.GetRandomElement();
        Nose = modularDataSet.Nose.GetRandomElement();
    }
}