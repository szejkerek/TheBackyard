using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunnerAfterPlayer : RunnerAfter
{
    private void Update()
    {
        closestRunner = GetClosestRunner(runners);
        taggingTimer += Time.deltaTime;
        TagRunner();
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
            //Debug.Log("Distance is bigger than radius. PLAYER");
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
