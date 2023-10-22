using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(-45f, -135f, 0f);
    }
}
