using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static GameObject GetRandomElement(this List<GameObject> list)
    {
        if (list.Count == 0)
        {
            Debug.LogError($"List is empty!!!");
            return null;
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
}