using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the animation of the player character based on input.
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{
    private Transform sprite;
    private Animator animator;

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = transform.Find("Sprite").transform;
    }

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.05f)
        {
            sprite.localScale = new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal")) * -1, 1, 1);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.05f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.05f)
        {
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
    }
}