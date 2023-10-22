using UnityEngine;
using UnityEngine.AI;

public class RunnerAfterBot : RunnerAfter
{
    private float maxDelay = 0.5f;
    [SerializeField] float currentDelay = 0;
    [SerializeField] private float runningSpeed;
    [SerializeField] private NavMeshAgent agent;

    private float minWiggleAngle = 20f;
    private float maxWiggleAngle = 90.0f;

    private float minDirectionChangeDelay = 0.2f;
    private float maxDirectionChangeDelay = 0.6f;

    private float currentRandomAngle = 0f;
    private float minDistanceFromRunner = 15f;

    private void Start()
    {
        currentDelay = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runningSpeed;
    }

    void Update()
    {
        closestRunner = GetClosestRunner(runners);
        taggingTimer += Time.deltaTime;

        if (currentRunnerAfter == this)
        {
            agent.destination = closestRunner.transform.position;
            TagRunner();
            return;
        }

        Vector3 destination = Vector3.zero;

        if(Vector3.Distance(transform.position , currentRunnerAfter.transform.position) < minDistanceFromRunner)
        {
            agent.stoppingDistance = 0f;
            Vector3 runDirection = (transform.position - currentRunnerAfter.transform.position).normalized;
            runDirection = Quaternion.AngleAxis(currentRandomAngle, Vector3.up) * runDirection;
            destination = (transform.position + runDirection * runningSpeed);
        }
        else
        {
            agent.stoppingDistance = 15f;
        }

        if(currentDelay > maxDelay)
        {
            maxDelay = Random.Range(minDirectionChangeDelay, maxDirectionChangeDelay);
            currentRandomAngle = Mathf.Sign(Random.Range(-1f, 1f)) * Random.Range(minWiggleAngle, maxWiggleAngle);
            currentDelay = 0;
        }
        currentDelay += Time.deltaTime;
        agent.SetDestination(destination);
    }

    public override void TagRunner()
    {
        if (currentRunnerAfter != this)
        {
            return;
        }
        if (closestRunner == null)
        {
            return;
        }

        float distance = Vector3.Distance(taggingRange.transform.position, closestRunner.transform.position);

        if (distance > taggingRange.radius)
        {
            return;
        }

        if (taggingTimer > taggingCooldown)
        {
            Debug.Log("Tagging closest runner. BOT");
            taggingTimer = 0;
            currentRunnerAfter = closestRunner;

            RunningAfterManager.Instance.UpdateRunnerAfter(closestRunner);
        }

    }
}
