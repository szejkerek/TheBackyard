using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModularDataSet", menuName = "ModularDataSet")]
public class ModularDataSet : ScriptableObject
{
    [field: SerializeField] public List<GameObject> Head { private set; get; }
    [field: SerializeField] public List<GameObject> Body { private set; get; }
    [field: SerializeField] public List<GameObject> Pants { private set; get; }
}

public class PlayableCharacterModularSet
{
    public GameObject Head;
    public GameObject Body;
    public GameObject Pants;

    public void RandomizeSet(ModularDataSet modularDataSet)
    {
        Head = modularDataSet.Head.GetRandomElement();
        Body = modularDataSet.Body.GetRandomElement();
        Pants = modularDataSet.Pants.GetRandomElement();
    }
}
