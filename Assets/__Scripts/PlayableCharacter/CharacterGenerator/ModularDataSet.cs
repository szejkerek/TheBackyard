using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModularDataSet", menuName = "ModularDataSet")]
public class ModularDataSet : ScriptableObject
{
    [field: SerializeField] public List<Color> SkinColor { private set; get; }
    [field: SerializeField] public List<Color> HairColor { private set; get; }
    [field: SerializeField] public List<Color> ShoeColor { private set; get; }
    [field: SerializeField] public List<Sprite> Body { private set; get; }
    [field: SerializeField] public List<Sprite> Hair { private set; get; }
    [field: SerializeField] public List<Sprite> Brows { private set; get; }
    [field: SerializeField] public List<Sprite> Mouth { private set; get; }
    [field: SerializeField] public List<Sprite> Eyes { private set; get; }
    [field: SerializeField] public List<Sprite> Nose { private set; get; }
}

[System.Serializable]
public class PlayableCharacterModularSet
{
    public Color SkinColor;
    public Color HairColor;
    public Color ShoeColor;
    public Sprite Body;
    public Sprite Hair;
    public Sprite Brows;
    public Sprite Mouth;
    public Sprite Eyes;
    public Sprite Nose;

    public void RandomizeSet(ModularDataSet modularDataSet)
    {
        SkinColor = modularDataSet.SkinColor[Random.Range(0, modularDataSet.SkinColor.Count)];
        HairColor = modularDataSet.HairColor[Random.Range(0, modularDataSet.HairColor.Count)];
        ShoeColor = modularDataSet.ShoeColor[Random.Range(0, modularDataSet.ShoeColor.Count)];
        Body = modularDataSet.Body[Random.Range(0, modularDataSet.Body.Count)];
        Hair =  modularDataSet.Hair[Random.Range(0, modularDataSet.Hair.Count)];
        Brows = modularDataSet.Brows[Random.Range(0, modularDataSet.Brows.Count)];
        Mouth = modularDataSet.Mouth[Random.Range(0, modularDataSet.Mouth.Count)];
        Eyes = modularDataSet.Eyes[Random.Range(0, modularDataSet.Eyes.Count)];
        Nose = modularDataSet.Nose[Random.Range(0, modularDataSet.Nose.Count)];
    }
}
