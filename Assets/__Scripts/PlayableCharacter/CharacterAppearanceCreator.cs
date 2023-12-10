using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsible for creating character appearances based on modular sets.
/// </summary>
public class CharacterAppearanceCreator : MonoBehaviour
{
    /// <summary>
    /// Modular dataset containing various customizable elements.
    /// </summary>
    [SerializeField] private ModularDataSet modularDataSet;

    /// <summary>
    /// SpriteRenderer for the character's body.
    /// </summary>
    [SerializeField] private SpriteRenderer Body;

    /// <summary>
    /// SpriteRenderer for the character's hair.
    /// </summary>
    [SerializeField] private SpriteRenderer Hair;

    /// <summary>
    /// SpriteRenderer for the character's eyebrows.
    /// </summary>
    [SerializeField] private SpriteRenderer Brows;

    /// <summary>
    /// SpriteRenderer for the character's mouth.
    /// </summary>
    [SerializeField] private SpriteRenderer Mouth;

    /// <summary>
    /// SpriteRenderer for the character's eyes.
    /// </summary>
    [SerializeField] private SpriteRenderer Eyes;

    /// <summary>
    /// SpriteRenderer for the character's nose.
    /// </summary>
    [SerializeField] private SpriteRenderer Nose;

    /// <summary>
    /// SpriteRenderer for the character's right hand.
    /// </summary>
    [SerializeField] private SpriteRenderer HandR;

    /// <summary>
    /// SpriteRenderer for the character's left hand.
    /// </summary>
    [SerializeField] private SpriteRenderer HandL;

    /// <summary>
    /// SpriteRenderer for the character's head.
    /// </summary>
    [SerializeField] private SpriteRenderer Head;

    /// <summary>
    /// SpriteRenderer for the character's right leg.
    /// </summary>
    [SerializeField] private SpriteRenderer LegR;

    /// <summary>
    /// SpriteRenderer for the character's left leg.
    /// </summary>
    [SerializeField] private SpriteRenderer LegL;

    /// <summary>
    /// Generates a character appearance based on the provided <paramref name="customModular"/>.
    /// </summary>
    /// <param name="customModular">Customized modular set for the character appearance.</param>
    public void GenerateCharacterAppearance(CustomModularSet customModular)
    {
        Body.sprite = customModular.Body;
        Hair.color = customModular.HairColor;
        Hair.sprite = customModular.Hair;
        Brows.color = customModular.HairColor;
        Brows.sprite = customModular.Brows;
        Mouth.sprite = customModular.Mouth;
        Eyes.sprite = customModular.Eyes;
        Nose.sprite = customModular.Nose;

        HandR.color = customModular.SkinColor;
        HandL.color = customModular.SkinColor;
        Head.color = customModular.SkinColor;

        LegL.color = customModular.ShoeColor;
        LegR.color = customModular.ShoeColor;
    }

    /// <summary>
    /// Randomizes the character appearance using the modular dataset.
    /// </summary>
    /// <returns>The randomized modular set for the character appearance.</returns>
    public CustomModularSet RandomizeSet()
    {
        CustomModularSet randomizedSet = new CustomModularSet();
        randomizedSet.RandomizeSet(modularDataSet);
        GenerateCharacterAppearance(randomizedSet);
        return randomizedSet;
    }
}