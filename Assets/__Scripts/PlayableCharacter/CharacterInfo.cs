using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class CharacterInfo
{
    public CharacterStats stats;
    public CustomModularSet customSet;

    public CharacterInfo(CharacterStats stats, CustomModularSet customSet)
    {
        this.stats = stats;
        this.customSet = customSet;
    }

    public CharacterInfo()
    {
        stats = new CharacterStats();
        customSet = new CustomModularSet();

    }
}

[System.Serializable]
public class CharacterStats
{
    public float agility = 5;
    public float speed = 5;

    public void RandomizeStats()
    {
        agility = Random.Range(0.1f, 1f);
        speed = Random.Range(0.1f, 1f);
    }

}