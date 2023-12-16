using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static class providing extension methods for generic lists.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Gets a random element from the list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to retrieve a random element from.</param>
    /// <returns>A randomly selected element from the list.</returns>
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