using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RunningAfterManager : Singleton<RunningAfterManager>
{
    [SerializeField] ArenaManager arena;
    [SerializeField] private List<RunnerAfter> runners;
    private RunnerAfter currentRunnerAfter;
    public RunnerAfter previousRunnerAfter = null;

    [SerializeField] private float gameTime = 120f;
    private float currentTime = 120f;

    [SerializeField] private TextMeshProUGUI timeText;

    public void UpdateRunnerAfter(RunnerAfter currentRunner)
    {
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Click2);

        previousRunnerAfter = currentRunnerAfter;
        if(previousRunnerAfter != null) Debug.Log(previousRunnerAfter.gameObject.name);
        currentRunnerAfter = currentRunner;
        foreach (var runner in runners)
        {
            runner.currentRunnerAfter = currentRunner;
            runner.previousRunnerAfter = previousRunnerAfter;
            runner.taggingTimer = 0;
        }
    }

    private void Start()
    {
        currentTime = gameTime;

        runners = FindObjectsByType<RunnerAfter>(FindObjectsSortMode.InstanceID).ToList();
        var randomRunnerIndex = Random.Range(0, runners.Count);

        foreach (var runner in runners)
        {
            runner.runners = runners;
            runner.currentRunnerAfter = runners[randomRunnerIndex];
        }

        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.PlayTag);
    }

    public bool GameWon()
    {
        AudioManager.Instance.StopGlobalSound();
        //AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Win);
        return !(RunnerAfterPlayer)currentRunnerAfter;
    }
    bool winOnce = false;
    private void Update()
    {
        if(currentTime <= 0)
        {
            if (winOnce)
                return;

            var gameWon = GameWon();
            if(gameWon)
            {
                AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Win);
                arena.WinArena();
            }
            else
            {
                AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Lose);
                arena.LoseArena();
            }
            winOnce = true;

            return;
        }
        currentTime -= Time.deltaTime;
        timeText.text = "TIME: " + (int)currentTime;
    }

}
