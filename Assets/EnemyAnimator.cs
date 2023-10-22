using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    private Transform sprite;
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        animator.SetBool("isIdle", false);
        //sprite = transform.Find("Sprite").transform;
        //agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        /*if (Mathf.Abs(agent.velocity.x) > 0.05f)
        {
            sprite.localScale = new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal")) * -1, 1, 1);
        }
        if (Mathf.Abs(agent.velocity.x) > 0.05f || (Mathf.Abs(agent.velocity.y) > 0.05f)) animator.SetBool("isIdle", false);
        else animator.SetBool("isIdle", true);*/
    }
}
