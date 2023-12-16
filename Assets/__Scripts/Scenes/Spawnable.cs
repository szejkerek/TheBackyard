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
    /// Generates a random position within the specified range and checks for collisions.
    /// </summary>
    public void GeneratePosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnPosMin.x, spawnPosMax.x), 0,
                Random.Range(spawnPosMin.y, spawnPosMax.y));

        if (Physics.CheckBox(new Vector3(spawnPos.x, 1f, spawnPos.y), new Vector3(2f, 0.1f, 2f)))
        {
            Debug.Log(":C");
            GeneratePosition();
        }
        else
        {
            transform.position = spawnPos;
        }
    }
}