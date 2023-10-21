using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerAfter : MonoBehaviour
{
    public RunnerAfter currentRunnerAfter;
    public RunnerAfter closestRunner;

    [SerializeField] protected SphereCollider taggingRange;
    [SerializeField] protected float taggingCooldown;
    public float taggingTimer;
    public List<RunnerAfter> runners;

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
            if (obj == this)
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

        //Debug.Log($"Found closest runner at distance: {closestDistance}");
        return closestObject;
    }

    public virtual void TagRunner()
    {
    }


    void Awake()
    {
        taggingRange = gameObject.AddComponent<SphereCollider>();
        taggingRange.radius = 2.5f;
        taggingRange.isTrigger = true;
    }
}
