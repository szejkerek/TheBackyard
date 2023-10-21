using TMPro;
using UnityEngine;

public class DayManagement : Singleton<DayManagement>
{ 
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_InputField possibleWin;
    [SerializeField] TMP_InputField possibleLoss;
    [SerializeField] TMP_InputField timeLoss;

    CycleManager cycleManager;

    private void Start()
    {
        cycleManager = MetaGameplayManager.Instance.CycleManager;
        timeText.text = $"Time left: {cycleManager.HoursLeft}h";
    }

    public void GoIntoArena(int characterIndex) 
    {
        int hoursLeft = MetaGameplayManager.Instance.CycleManager.HoursLeft;
        ArenaInformation info = GatherArenaInformatio();
        if(info.timeLoss >= hoursLeft)
        {
            Debug.LogWarning($"Cannot Go to this arena with {hoursLeft} hours left");
            return;
        }
        info.character = GameManager.Instance.PlayableCharacters[characterIndex];
        GameManager.Instance.SetArenaInformation(info);
        SceneManager.Instance.LoadScene(2);
    }

    private ArenaInformation GatherArenaInformatio()
    {
        ArenaInformation temp = new ArenaInformation();
        temp.character = null;
        temp.moneyWin = int.Parse(possibleWin.text);
        temp.moneyLoss = int.Parse(possibleLoss.text);
        temp.timeLoss = int.Parse(timeLoss.text);

        return temp;
    }
}
