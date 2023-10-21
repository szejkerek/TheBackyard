using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPlaygroundSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> SpawnablesBig, SpawnableSmall;
    [SerializeField]
    private Vector2 MinPos, MaxPos;
    [SerializeField]
    private int BigSpawnCount, SmallSpawnCount;

    void Start()
    {
        for (int i = 0; i < BigSpawnCount; i++)
        {
            GameObject objectToSpawn = SpawnablesBig[Random.Range(0, SpawnablesBig.Count)];
            Vector3 spawnPos = new Vector3(Random.Range(MinPos.x, MaxPos.x), 0,
                Random.Range(MinPos.y,MaxPos.y));

            GameObject spawnedObject = Instantiate(objectToSpawn, new Vector3(0, -100, 0), 
                            Quaternion.Euler(new Vector3(0, Random.Range(0, 8)*45, 0)));
            Spawnable spawnable = spawnedObject.GetComponent<Spawnable>();
            spawnable.spawnPosMin = MinPos;
            spawnable.spawnPosMax = MaxPos;
            spawnable.GeneratePosition();
        }
    }

}
