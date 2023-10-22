using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManagement : Singleton<DayManagement>
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject minigamePicker;
    [SerializeField] GameObject characterPicker;


    CycleManager cycleManager;
    ArenaInformation arenaInformation;
    private void Start()
    {
        characterPicker.gameObject.SetActive(false);
        cycleManager = MetaGameplayManager.Instance.CycleManager;
        timeText.text = $"Time left: {cycleManager.HoursLeft}h";
    }

    public void GoIntoArena(int characterIndex) 
    {
        if (arenaInformation == null)
        {
            Debug.LogWarning($"Arena information is null");
            return;
        }
        arenaInformation.character = GameManager.Instance.PlayableCharacters[characterIndex];
        GameManager.Instance.SetArenaInformation(arenaInformation);
        SceneManager.Instance.LoadScene(2);
    }

    public void SetArenaInformation(ArenaInformation newArenaInformation)
    {
        int hoursLeft = MetaGameplayManager.Instance.CycleManager.HoursLeft;
        arenaInformation = newArenaInformation;
        if (arenaInformation.timeLoss >= hoursLeft)
        {
            Debug.LogWarning($"Cannot Go to this arena with {hoursLeft} hours left");
            return;
        }
        minigamePicker.gameObject.SetActive(false);
        characterPicker.gameObject.SetActive(true);
    }
}
