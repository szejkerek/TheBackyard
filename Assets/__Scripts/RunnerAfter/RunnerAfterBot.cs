using UnityEngine;
using UnityEngine.AI;

public class RunnerAfterBot : RunnerAfter
{
    [SerializeField] float maxDelay = 5.0f;
    [SerializeField] float currentDelay = 0;
    [SerializeField] private float runningSpeed;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float randomMovementWiggleMaxRange = 7.0f;

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

        Vector3 runDirection = transform.position - currentRunnerAfter.transform.position;
        runDirection.Normalize();
        Vector3 destination = (transform.position + runDirection * runningSpeed);

        if(currentDelay > maxDelay)
        {
            destination = Quaternion.Euler(0.0f, Random.Range(-randomMovementWiggleMaxRange, randomMovementWiggleMaxRange), 0.0f) * destination;
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
