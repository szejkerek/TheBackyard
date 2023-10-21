using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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
    
    private PlayerMovement pm;
    private CameraTargetFollower ctf;
    private TriggerTimer winTimer;

    private int touchesSoFar = 0;
    private int sign = 1;
    private int currentStep = 0;

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

    void Start()
    {
        lavaPool.gameObject.SetActive(true);
        lavaPool.Active = false;

        CycleThroughLavaPoolState();

        lavaPool.OnLavaTrigger.AddListener(OnObjectLavaTrigger);

        Invoke(nameof(SuddenDeath), secondsToSuddenDeath);
    }

    void Update()
    {
        winTimer.Update(Time.deltaTime * 1000.0f);
        timeLeft = Clock.FormatToMinSec((int)winTimer.TimeLeft);
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
        touchesSoFar++;
    }

    void SuddenDeath()
    {
        CancelInvoke();

        lavaPool.UpwardsGrowthPerSecond = suddenDeathGrowthPerSecond;
        lavaPool.Active = true;
    }

    void CycleThroughLavaPoolState()
    {
        lavaPool.UpwardsGrowthPerSecond = growthSteps[currentStep] * sign;
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

        Debug.Log("Player won");
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
        
        Debug.Log("Player lost :OOOO");
    }
}
