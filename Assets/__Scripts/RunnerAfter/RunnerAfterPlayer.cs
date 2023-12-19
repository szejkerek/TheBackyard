using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Represents the player-controlled runner in a tagging game.
/// </summary>
public class RunnerAfterPlayer : RunnerAfter
{
    /// <summary>
    /// Updates the player-controlled runner's behavior based on the game logic.
    /// </summary>
    private void Update()
    {
        closestRunner = GetClosestRunner(runners);
        taggingTimer += Time.deltaTime;
        TagRunner();
    }

    /// <summary>
    /// Overrides the base class method to implement specific tagging behavior for the player.
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
            // Debug.Log("Distance is bigger than radius. PLAYER");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && taggingTimer >= taggingCooldown)
        {
            Debug.Log("Tagging closest runner. PLAYER");
            taggingTimer = 0;
            currentRunnerAfter = closestRunner;

            RunningAfterManager.Instance.UpdateRunnerAfter(closestRunner);
        }
    }
}