using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Represents a bot runner in a tagging game with additional behaviors specific to bots.
/// </summary>
public class RunnerAfterBot : RunnerAfter
{
    /// <summary>
    /// The maximum delay for direction change.
    /// </summary>
    private float maxDelay = 0.5f;

    /// <summary>
    /// The current delay for direction change.
    /// </summary>
    [SerializeField] float currentDelay = 0;

    /// <summary>
    /// The running speed of the bot.
    /// </summary>
    [SerializeField] private float runningSpeed;

    /// <summary>
    /// The NavMeshAgent for the bot's navigation.
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    /// <summary>
    /// The minimum wiggle angle during navigation.
    /// </summary>
    private float minWiggleAngle = 20f;

    /// <summary>
    /// The maximum wiggle angle during navigation.
    /// </summary>
    private float maxWiggleAngle = 90.0f;

    /// <summary>
    /// The minimum delay for changing direction.
    /// </summary>
    private float minDirectionChangeDelay = 0.2f;

    /// <summary>
    /// The maximum delay for changing direction.
    /// </summary>
    private float maxDirectionChangeDelay = 0.6f;

    /// <summary>
    /// The current random angle for navigation.
    /// </summary>
    private float currentRandomAngle = 0f;

    /// <summary>
    /// The minimum distance from the runner.
    /// </summary>
    private float minDistanceFromRunner = 15f;

    /// <summary>
    /// Initializes the bot runner.
    /// </summary>
    private void Start()
    {
        currentDelay = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runningSpeed;
    }

    /// <summary>
    /// Updates the bot's behavior based on the game logic.
    /// </summary>
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

        if (Vector3.Distance(transform.position, currentRunnerAfter.transform.position) < minDistanceFromRunner)
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

        if (currentDelay > maxDelay)
        {
            maxDelay = Random.Range(minDirectionChangeDelay, maxDirectionChangeDelay);
            currentRandomAngle = Mathf.Sign(Random.Range(-1f, 1f)) * Random.Range(minWiggleAngle, maxWiggleAngle);
            currentDelay = 0;
        }
        currentDelay += Time.deltaTime;
        agent.SetDestination(destination);
    }

    /// <summary>
    /// Overrides the base class method to implement specific tagging behavior for bots.
    /// </summary>
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