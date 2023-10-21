using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPlaygroundSpawner : MonoBehaviour
{
    public GameObject[] SpawnablesBig;
    public GameObject[] SpawnableSmall;
    public Vector3 BottomLeft, TopRight;
    public int BigSpawnCount, SmallSpawnCount;
    public float SpawnHeight;

    void Start()
    {
        for (int i = 0; i < BigSpawnCount; i++)
        {
            int SpawnablesArrayIndex = Random.Range(0, SpawnablesBig.Length);
            Vector3 pos = new Vector3(Random.Range(BottomLeft.x, TopRight.x), SpawnHeight,
                Random.Range(BottomLeft.z,TopRight.z));

            GameObject g = Instantiate(SpawnablesBig[SpawnablesArrayIndex], pos, 
                            Quaternion.Euler(new Vector3(0, Random.Range(1, 8)*45, 0)));
            
            g.transform.parent = transform;
            
        }
    }

}
