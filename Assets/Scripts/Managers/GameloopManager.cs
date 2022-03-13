using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using HUDCore;

public class GameloopManager : MonoBehaviourSingleton<GameloopManager>
{
    public event Action<GunValues> OnPlayerShoot;
    public event Action<LevelStartAction> OnLevelStart;


    public void InvokeLevelStarted()
    {
        LevelStartAction levelStartAction = new LevelStartAction();
        levelStartAction.GunValues = new GunValues(5, 5);//Using pistol as a default
        OnLevelStart?.Invoke(levelStartAction);
    }

    public void InvokePlayerShotEvent(GunValues action)
    {
        OnPlayerShoot?.Invoke(action);
    }


}


public struct LevelStartAction
{
    public GunValues GunValues;

}


public struct GunValues
{

    public int CurrentCount;
    public int MaxCount;
    public GunValues(int currentCount, int maxCount)
    {
        CurrentCount = currentCount;
        MaxCount = maxCount;
    }

    public static GunValues DidntShoot(int currentVal, int maxVal)
    {
        return new GunValues(currentVal, maxVal);
    }
}
