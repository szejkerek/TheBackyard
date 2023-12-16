using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Spawns random GameObjects within a specified area.
/// </summary>
public class RandomPlaygroundSpawner : MonoBehaviour
{
    /// <summary>
    /// Array of big GameObjects that can be spawned.
    /// </summary>
    public GameObject[] SpawnablesBig;

    /// <summary>
    /// Array of small GameObjects that can be spawned.
    /// </summary>
    public GameObject[] SpawnableSmall;

    /// <summary>
    /// Bottom-left corner of the spawning area.
    /// </summary>
    public Vector3 BottomLeft;

    /// <summary>
    /// Top-right corner of the spawning area.
    /// </summary>
    public Vector3 TopRight;

    /// <summary>
    /// Number of big GameObjects to spawn.
    /// </summary>
    public int BigSpawnCount;

    /// <summary>
    /// Number of small GameObjects to spawn.
    /// </summary>
    public int SmallSpawnCount;

    /// <summary>
    /// Height at which the GameObjects will be spawned.
    /// </summary>
    public float SpawnHeight;

    /// <summary>
    /// Initializes the spawner by randomly instantiating big GameObjects within the specified area.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < BigSpawnCount; i++)
        {
            int SpawnablesArrayIndex = Random.Range(0, SpawnablesBig.Length);
            Vector3 pos = new Vector3(
                Random.Range(BottomLeft.x, TopRight.x),
                SpawnHeight,
                Random.Range(BottomLeft.z, TopRight.z)
            );

            GameObject g = Instantiate(
                SpawnablesBig[SpawnablesArrayIndex],
                pos,
                Quaternion.Euler(new Vector3(0, Random.Range(1, 8) * 45, 0))
            );

            g.transform.parent = transform;
        }
    }
}