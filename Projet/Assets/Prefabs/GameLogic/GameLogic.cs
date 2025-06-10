using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameLogic : MonoBehaviour
{
    protected bool conditionDone;
    public GameLogicManager gameLogicManager;
    public abstract bool IsGameLogicTrue();
    public abstract void SideEffect();
    public abstract void ReverseSideEffect();

    public void Start()
    {
        gameLogicManager.SubscribeItself(this);
    }
}
