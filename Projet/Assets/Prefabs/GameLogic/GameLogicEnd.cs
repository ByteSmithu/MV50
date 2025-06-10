using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameLogicEnd : MonoBehaviour
{
    
    public GameLogicManager gameLogicManager;
    public abstract void Won();
    
    public void Start()
    {
        gameLogicManager.SubscribeItself(this);
    }

}
