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
public class CustomModularSet
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
        SkinColor = modularDataSet.SkinColor.GetRandomElement();
        HairColor = modularDataSet.HairColor.GetRandomElement();
        ShoeColor = modularDataSet.ShoeColor.GetRandomElement();
        Body = modularDataSet.Body.GetRandomElement();
        Hair =  modularDataSet.Hair.GetRandomElement();    
        Brows = modularDataSet.Brows.GetRandomElement();
        Mouth = modularDataSet.Mouth.GetRandomElement();
        Eyes = modularDataSet.Eyes.GetRandomElement();
        Nose = modularDataSet.Nose.GetRandomElement();
    }
}
