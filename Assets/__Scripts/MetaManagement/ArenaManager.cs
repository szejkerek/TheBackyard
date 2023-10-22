using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : Singleton<ArenaManager>
{
    ArenaInformation currentInfo;
    private void Start()
    {
        currentInfo = GameManager.Instance.ArenaInformation;

        if (currentInfo == null)
        {
            Debug.LogError("Couldn't get arena information!");
            currentInfo = DebugArenaInfo();
        }
    }

    public void WinArena()
    {
        MetaGameplayManager meta = MetaGameplayManager.Instance;
        meta.MoneyHolder.AddMoney(currentInfo.moneyWin);
        meta.CycleManager.DecrementHours(currentInfo.timeLoss);
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    public void LoseArena()
    {
        MetaGameplayManager meta = MetaGameplayManager.Instance;
        meta.MoneyHolder.RemoveMoney(currentInfo.moneyLoss);
        meta.CycleManager.DecrementHours((int) (currentInfo.timeLoss));
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    private ArenaInformation DebugArenaInfo()
    {
        Debug.Log("Generating debug arena info");
        ArenaInformation info = new ArenaInformation();
        info.moneyWin = 0;
        info.moneyLoss = 0;
        info.timeLoss = 0;
        return info;
    }
}
