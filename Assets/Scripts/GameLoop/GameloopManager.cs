using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class GameloopManager : MonoBehaviourSingleton<GameloopManager>
{
    public event Action<GunValues> OnPlayerShootAction;
    public event Action<LevelStartAction> OnLevelStartAction;


    public void InvokeLevelStarted()
    {
        LevelStartAction levelStartAction = new LevelStartAction();
        levelStartAction.GunValues = new GunValues(5, 5);//Using pistol as a default
        OnLevelStartAction?.Invoke(levelStartAction);

        OnLevelStartAction = null;
    }

    public void InvokePlayerShotAction(GameLoopAction<GunValues> action)
    {
        GunValues data = (GunValues)action.Value;

        OnPlayerShootAction?.Invoke(data);
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
}

public struct GameLoopAction<T> where T : struct
{
    public T? Value;
    public bool hasActionData { get { return Value.HasValue; } }

}
