using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class RisingLava : MonoBehaviour
{
    public UnityEvent<GameObject> OnLavaTrigger;

    [SerializeField] private float upwardsGrowthPerSecond = 1.0f;
    [SerializeField] private float toggleInterval = 2.0f;
    [SerializeField] private bool active = false;
    
    public float UpwardsGrowthPerSecond { get { return upwardsGrowthPerSecond; } set { upwardsGrowthPerSecond = value; } }
    public bool Active { get { return active; } set { active = value; CancelInvoke(); } }

    void Start()
    {
        // SetActiveForInterval();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnLavaTrigger.Invoke(other.gameObject);
    }

    void Update()
    {
        if(!active)
        {
            return;
        }
        

        transform.position += Time.deltaTime * upwardsGrowthPerSecond * Vector3.up;
    }

    void SetActiveForInterval()
    {
        active = true;

        Invoke(nameof(SetInactiveForInterval), toggleInterval);
    }

    void SetInactiveForInterval()
    {
        active = false;

        Invoke(nameof(SetActiveForInterval), toggleInterval);
    }
}
