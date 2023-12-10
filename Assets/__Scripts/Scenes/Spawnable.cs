using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an object that can be spawned within a specified range.
/// </summary>
public class Spawnable : MonoBehaviour
{
    /// <summary>
    /// The minimum spawn position in the x and y coordinates.
    /// </summary>
    public Vector2 spawnPosMin;

    /// <summary>
    /// The maximum spawn position in the x and y coordinates.
    /// </summary>
    public Vector2 spawnPosMax;

    /// <summary>
    /// Flag indicating whether a valid position has been found for spawning.
    /// </summary>
    private bool positionFound = false;

    /// <summary>
    /// Generates a random position within the specified range and checks for collisions.
    /// </summary>
    public void GeneratePosition()
    {
        // Generate a random position within the specified range
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosMin.x, spawnPosMax.x), 0,
                Random.Range(spawnPosMin.y, spawnPosMax.y));

        // Check for collisions using a box
        if (Physics.CheckBox(new Vector3(spawnPos.x, 1f, spawnPos.y), new Vector3(2f, 0.1f, 2f)))
        {
            // If a collision is detected, log a message and recursively generate a new position
            Debug.Log(":C");
            GeneratePosition();
        }
        else
        {
            // If no collision is detected, set the object's position to the generated position
            transform.position = spawnPos;
        }
    }
}