using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controls the behavior of rising lava, triggering events when objects enter the lava.
/// </summary>
public class RisingLava : MonoBehaviour
{
    /// <summary>
    /// Event triggered when an object enters the lava.
    /// </summary>
    public UnityEvent<GameObject> OnLavaTrigger;

    [SerializeField] private float upwardsGrowthPerSecond = 1.0f;
    [SerializeField] private float toggleInterval = 2.0f;
    [SerializeField] private bool active = false;

    /// <summary>
    /// Gets or sets the rate at which the lava grows upwards per second.
    /// </summary>
    public float UpwardsGrowthPerSecond { get { return upwardsGrowthPerSecond; } set { upwardsGrowthPerSecond = value; } }

    /// <summary>
    /// Gets or sets whether the rising lava is currently active.
    /// </summary>
    public bool Active { get { return active; } set { active = value; CancelInvoke(); } }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        // SetActiveForInterval();
    }

    /// <summary>
    /// Called when a Collider enters the trigger zone.
    /// Triggers the OnLavaTrigger event.
    /// </summary>
    /// <param name="other">The Collider entering the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        OnLavaTrigger.Invoke(other.gameObject);
    }

    /// <summary>
    /// Called once per frame.
    /// Moves the lava upwards if it is active.
    /// </summary>
    void Update()
    {
        if (!active)
        {
            return;
        }

        transform.position += Time.deltaTime * upwardsGrowthPerSecond * Vector3.up;
    }

    /// <summary>
    /// Activates the rising lava for a specified interval, then deactivates it.
    /// </summary>
    void SetActiveForInterval()
    {
        active = true;

        Invoke(nameof(SetInactiveForInterval), toggleInterval);
    }

    /// <summary>
    /// Deactivates the rising lava for a specified interval, then activates it.
    /// </summary>
    void SetInactiveForInterval()
    {
        active = false;

        Invoke(nameof(SetActiveForInterval), toggleInterval);
    }
}