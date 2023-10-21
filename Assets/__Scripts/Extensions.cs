using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomElement<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            Debug.LogError($"List is empty!!!");
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
}