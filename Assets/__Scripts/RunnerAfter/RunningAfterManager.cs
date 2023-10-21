using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunningAfterManager : Singleton<RunningAfterManager>
{
    [SerializeField] private List<RunnerAfter> runners;

    public void UpdateRunnerAfter(RunnerAfter currentRunner)
    {
        foreach (var runner in runners)
        {
            runner.currentRunnerAfter = currentRunner;
            runner.taggingTimer = 0;
        }
    }

    private void Start()
    {
        runners = FindObjectsByType<RunnerAfter>(FindObjectsSortMode.InstanceID).ToList();
        var randomRunnerIndex = Random.Range(0, runners.Count);

        foreach (var runner in runners)
        {
            runner.runners = runners;
            runner.currentRunnerAfter = runners[randomRunnerIndex];
        }
    }
}
