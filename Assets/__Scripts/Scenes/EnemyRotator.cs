using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the enemy GameObject to a fixed orientation.
/// </summary>
public class EnemyRotator : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(-45f, -135f, 0f);
    }
}