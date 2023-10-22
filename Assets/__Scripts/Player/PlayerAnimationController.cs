using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Transform sprite;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = transform.Find("Sprite").transform;
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.05f)
        {
            animator.SetBool("isIdle", false);
            sprite.localScale = new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal")) * -1, 1, 1);
        }
        else animator.SetBool("isIdle", true);
    }
}
