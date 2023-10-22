using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Transform sprite;

    void Start()
    {
        sprite = transform.Find("Sprite").transform;
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.05f)
        {
            sprite.localScale = new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal")) * -1, 1, 1);
        }
    }
}
