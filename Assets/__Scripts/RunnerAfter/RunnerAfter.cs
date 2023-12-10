using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents a runner in a tagging game, where the runner attempts to tag other runners within a certain range.
/// </summary>
public class RunnerAfter : MonoBehaviour
{
    /// <summary>
    /// The current instance of the runner.
    /// </summary>
    public RunnerAfter currentRunnerAfter;

    /// <summary>
    /// The previous runner instance in the tagging sequence.
    /// </summary>
    public RunnerAfter previousRunnerAfter = null;

    /// <summary>
    /// The closest runner in proximity to this runner.
    /// </summary>
    public RunnerAfter closestRunner;

    /// <summary>
    /// The sphere collider representing the tagging range.
    /// </summary>
    [SerializeField] protected SphereCollider taggingRange;

    /// <summary>
    /// The cooldown period for tagging in seconds.
    /// </summary>
    [SerializeField] protected float taggingCooldown;

    /// <summary>
    /// The timer to keep track of the tagging cooldown.
    /// </summary>
    public float taggingTimer;

    /// <summary>
    /// The list of all runners in the game.
    /// </summary>
    public List<RunnerAfter> runners;

    /// <summary>
    /// Gets the closest runner from a list of runners.
    /// </summary>
    /// <param name="runners">The list of runners to consider.</param>
    /// <returns>The closest runner.</returns>
    protected RunnerAfter GetClosestRunner(List<RunnerAfter> runners)
    {
        RunnerAfter closestObject = null;
        float closestDistance = float.MaxValue;

        if (runners.Count < 2)
        {
            Debug.Log($"No other runner found.");
            return this;
        }

        foreach (RunnerAfter obj in runners)
        {
            if (obj == this || obj == previousRunnerAfter)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        // Debug.Log($"Found closest runner at distance: {closestDistance}");
        return closestObject;
    }

    /// <summary>
    /// Tag the closest runner within the tagging range.
    /// </summary>
    public virtual void TagRunner()
    {
        // Implementation specific to the tagging behavior
    }

    /// <summary>
    /// Initializes the runner by adding a SphereCollider for tagging range.
    /// </summary>
    void Awake()
    {
        taggingRange = gameObject.AddComponent<SphereCollider>();
        taggingRange.radius = 2.5f;
        taggingRange.isTrigger = true;
    }
}