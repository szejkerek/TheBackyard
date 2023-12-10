using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Tayx.Graphy.Utils.NumString;
using System;

/// <summary>
/// Manages the gameplay of the lava mini-game.
/// </summary>
public class LavaGameManager : MonoBehaviour
{
    [Header("Game settings")]
    [SerializeField] private int touchLimit;
    [SerializeField] private int touchUpwardsForce;
    [SerializeField] private int gameTimeInSeconds;
    [SerializeField] private float lavaDropdownSpeed;
    public UnityEvent playerWonEvent;
    public UnityEvent playerLostEvent;

    [Header("Regular state")]
    [SerializeField] private float[] growthSteps = { 1, 1, 2, 2, 3, 3 };
    [SerializeField] private int[] intervalsBetweenSteps = { 2, 2, 3, 3, 4, 4 };

    [Space]
    [Header("Sudden death")]
    [SerializeField] private float suddenDeathGrowthPerSecond;
    [SerializeField] private float secondsToSuddenDeath;

    [Space]
    [Header("References")]
    [SerializeField] private RisingLava lavaPool;
    [SerializeField] private GameObject player;

    [Space]
    [Header("Heretic debug")]
    [SerializeField] private string timeLeft;
    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private bool timerIsRunning = false;

    [Space]
    [Header("Timer display")]
    [SerializeField] private TMP_Text timerText;

    private PlayerMovement pm;
    private CameraTargetFollower ctf;
    private TriggerTimer winTimer;

    private int touchesSoFar = 0;
    private int sign = 1;
    private int currentStep = 0;
    private bool lavaHasStarted = false;

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// </summary>
    private void Awake()
    {
        if (player)
        {
            pm = player.GetComponent<PlayerMovement>();
        }

        ctf = FindObjectOfType<CameraTargetFollower>();

        winTimer = new();
        winTimer.SetInterval(gameTimeInSeconds * 1000.0f);
        winTimer.SetTriggerFunction(OnPlayerWon);
        winTimer.SetSingleShot(true);
        winTimer.Start();
    }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        timerIsRunning = true;
        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.FloorIsLava);
    }

    /// <summary>
    /// Called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                DisplayTime(timeRemaining.ToInt());
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                DisplayTime(timeRemaining.ToInt());

                timerIsRunning = false;
                lavaHasStarted = true;

                StartLava();
                winTimer.Update(Time.deltaTime * 1000.0f);
                timeLeft = Clock.FormatToMinSec((int)winTimer.TimeLeft);
            }
        }

        if (lavaHasStarted == true)
        {
            winTimer.Update(Time.deltaTime * 1000.0f);
            timeLeft = Clock.FormatToMinSec((int)winTimer.TimeLeft);
        }
    }

    /// <summary>
    /// Starts the lava mini-game.
    /// </summary>
    void StartLava()
    {
        lavaPool.gameObject.SetActive(true);
        lavaPool.Active = false;

        CycleThroughLavaPoolState();

        lavaPool.OnLavaTrigger.AddListener(OnObjectLavaTrigger);

        Invoke(nameof(SuddenDeath), secondsToSuddenDeath);
    }

    /// <summary>
    /// Called when an object triggers the lava.
    /// </summary>
    /// <param name="collidedObject">The object that triggered the lava.</param>
    void OnObjectLavaTrigger(GameObject collidedObject)
    {
        if (collidedObject != player || pm.Velocity.y > 0.0f)
        {
            return;
        }

        if (touchesSoFar >= touchLimit)
        {
            OnPlayerLost();
            return;
        }

        pm.JumpWithHeight(touchUpwardsForce);
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.SizzleOnce);
        touchesSoFar++;
    }

    /// <summary>
    /// Initiates sudden death mode for the lava.
    /// </summary>
    void SuddenDeath()
    {
        timerText.color = Color.red;
        CancelInvoke();

        lavaPool.UpwardsGrowthPerSecond = suddenDeathGrowthPerSecond;
        lavaPool.Active = true;
    }

    /// <summary>
    /// Cycles through different states of the lava pool.
    /// </summary>
    void CycleThroughLavaPoolState()
    {
        lavaPool.UpwardsGrowthPerSecond = MathF.Abs(growthSteps[currentStep] * sign);
        lavaPool.Active = !lavaPool.Active;
        Invoke(nameof(CycleThroughLavaPoolState), intervalsBetweenSteps[currentStep]);

        currentStep += sign;

        if (currentStep == -1 || currentStep == growthSteps.Length)
        {
            sign *= -1;
            currentStep += sign;
        }
    }

    /// <summary>
    /// Called when the player wins the mini-game.
    /// </summary>
    private void OnPlayerWon()
    {
        lavaPool.Active = true;
        lavaPool.UpwardsGrowthPerSecond = lavaDropdownSpeed;

        playerWonEvent?.Invoke();
        CancelInvoke();

        timerText.color = Color.green;
        Debug.Log("Player won");
        AudioManager.Instance.StopGlobalSound();
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Win);
    }

    /// <summary>
    /// Called when the player loses the mini-game.
    /// </summary>
    private void OnPlayerLost()
    {
        CancelInvoke();

        if (ctf)
        {
            ctf.enabled = false;
        }

        lavaPool.Active = false;
        lavaPool.OnLavaTrigger.RemoveListener(OnObjectLavaTrigger);

        playerLostEvent?.Invoke();
        winTimer.Stop();

        timerText.color = Color.red;
        Debug.Log("Player lost");
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.SizzleLong);
        AudioManager.Instance.StopGlobalSound();
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.Lose);
    }

    /// <summary>
    /// Displays the remaining time on the timer.
    /// </summary>
    /// <param name="timeToDisplay">The time remaining to be displayed.</param>
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay > 0)
            timerText.text = "Lava starts in: " + timeToDisplay.ToString();

        else
            timerText.text =  "";
    }
}
