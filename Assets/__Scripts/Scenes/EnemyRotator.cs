using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the enemy GameObject to a fixed orientation.
/// </summary>
public class EnemyRotator : MonoBehaviour
{
    /// <summary>
    /// Updates the rotation of the enemy to a fixed Euler angle.
    /// </summary>
    private void Update()
    {
        transform.rotation = Quaternion.Euler(-45f, -135f, 0f);
    }
}