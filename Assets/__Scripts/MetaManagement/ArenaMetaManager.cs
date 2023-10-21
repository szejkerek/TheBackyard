using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMetaManager : Singleton<ArenaMetaManager>
{
    ArenaInformation currentInfo;

    private void Start()
    {
        currentInfo = GameManager.Instance.ArenaInformation;

        if (currentInfo == null)
        {
            currentInfo = DebugArenaInfo();
            Debug.LogError("Couldn't get arena information!");
        }
    }

    public void WinArena()
    {
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);
    }

    public void LoseArena()
    {
        SceneManager.Instance.LoadScene(SceneEnum.DayManagmentScene);

    }

    private void ModifyMetaVariable()
    {

    }

    private ArenaInformation DebugArenaInfo()
    {
        ArenaInformation info = new ArenaInformation();
        info.moneyWin = 20;
        info.moneyLoss = 5;
        info.timeLoss = 5;
        return info;
    }
}
