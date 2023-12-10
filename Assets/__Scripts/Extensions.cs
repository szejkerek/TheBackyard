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
        // Check if the list is empty and log an error if so.
        if (list.Count == 0)
        {
            Debug.LogError($"List is empty!!!");
        }

        // Generate a random index within the bounds of the list.
        int randomIndex = Random.Range(0, list.Count);

        // Return the randomly selected element from the list.
        return list[randomIndex];
    }
}