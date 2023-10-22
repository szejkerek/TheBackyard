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

public class LavaGameManager : MonoBehaviour
{
    [Header("Game settings")]
    [SerializeField] private int touchLimit;
    [SerializeField] private int touchUpwardsFroce;
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



    private void Awake()
    {
        if(player)
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

    private void Start()
    {
        timerIsRunning = true;
        AudioManager.Instance.PlayGlobalMusic(AudioManager.Instance.MusicLib.FloorIsLava);
    }

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

        if(lavaHasStarted == true)
        {
            winTimer.Update(Time.deltaTime * 1000.0f);
            timeLeft = Clock.FormatToMinSec((int)winTimer.TimeLeft);
        }

    }
    void StartLava()
    {
        lavaPool.gameObject.SetActive(true);
        lavaPool.Active = false;

        CycleThroughLavaPoolState();

        lavaPool.OnLavaTrigger.AddListener(OnObjectLavaTrigger);

        Invoke(nameof(SuddenDeath), secondsToSuddenDeath);
    }

    void OnObjectLavaTrigger(GameObject collidedObject)
    {
        if (collidedObject != player || pm.Velocity.y > 0.0f)
        {
            return;
        }

        if(touchesSoFar >= touchLimit)
        {
            OnPlayerLost();

            return;
        }

        pm.JumpWithHeight(touchUpwardsFroce);
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.SizzleOnce);
        touchesSoFar++;
    }

    void SuddenDeath()
    {
        timerText.text = "You Lost, it was sudden";
        timerText.color = Color.red;
        CancelInvoke();

        lavaPool.UpwardsGrowthPerSecond = suddenDeathGrowthPerSecond;
        lavaPool.Active = true;
    }

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

    private void OnPlayerWon()
    {
        lavaPool.Active = true;
        lavaPool.UpwardsGrowthPerSecond = lavaDropdownSpeed;

        playerWonEvent?.Invoke();
        CancelInvoke();

        timerText.text = "You Won!";
        timerText.color = Color.green;
        Debug.Log("Player won");
        AudioManager.Instance.StopGlobalSound();
    }

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

        timerText.text = "You Lost";
        timerText.color = Color.red;
        Debug.Log("Player lost");
        AudioManager.Instance.PlayGlobalSound(AudioManager.Instance.SFXLib.SizzleLong);
        AudioManager.Instance.StopGlobalSound();
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay > 0)
            timerText.text = "Lava starts in: " + timeToDisplay.ToString();

        else
            timerText.text =  "";
    }
}
