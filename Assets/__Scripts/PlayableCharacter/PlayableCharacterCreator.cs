using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterCreator : MonoBehaviour
{
    [SerializeField]
    private ModularDataSet mds;
    [SerializeField]
    private Color SkinColor, ShoeColor;
    [SerializeField]
    private SpriteRenderer Body, Hair, Brows, Mouth, Eyes, Nose;
    [SerializeField]
    private SpriteRenderer HandR, HandL, Head;
    [SerializeField]
    private SpriteRenderer LegR, LegL;


    private void Start()
    {
        CreateCharacter(new PlayableCharacter(mds));
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            CreateCharacter(new PlayableCharacter(mds));
        }
    }

    public void CreateCharacter(PlayableCharacter playableCharacter)
    {
        GenerateCharacterImage(playableCharacter.PlayableCharacterModularSet);
    }

    private void GenerateCharacterImage(PlayableCharacterModularSet characterSet)
    {
        Body.sprite = characterSet.Body;
        Hair.color = characterSet.HairColor;
        Hair.sprite = characterSet.Hair;
        Brows.color = characterSet.HairColor;
        Brows.sprite = characterSet.Brows;
        Mouth.sprite = characterSet.Mouth;
        Eyes.sprite = characterSet.Eyes;
        Nose.sprite = characterSet.Nose;

        HandR.color = characterSet.SkinColor;
        HandL.color = characterSet.SkinColor;
        Head.color = characterSet.SkinColor;

        LegL.color = characterSet.ShoeColor;
        LegR.color = characterSet.ShoeColor;
    }
}
