using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAppearanceCreator : MonoBehaviour
{
    [SerializeField]
    private ModularDataSet modularDataSet;
    [SerializeField]
    private SpriteRenderer Body, Hair, Brows, Mouth, Eyes, Nose;
    [SerializeField]
    private SpriteRenderer HandR, HandL, Head;
    [SerializeField]
    private SpriteRenderer LegR, LegL;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            GenerateCharacterAppearance(new CharacterInfo(modularDataSet).CustomModularSet);
        }
    }

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
}
