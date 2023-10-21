using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public Vector2 spawnPosMin, spawnPosMax;
    private bool positionFound = false;

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
