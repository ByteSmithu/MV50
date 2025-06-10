using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    private List<GameLogic> gameLogics = new List<GameLogic>();
    private List<GameLogicEnd> endGameLogics = new List<GameLogicEnd>();

    public void Start()
    {
    }

    public void Actualize()
    {
        foreach (GameLogic gl in gameLogics)
        {
            if (!gl.IsGameLogicTrue())
                return;
        }

        foreach (GameLogicEnd gle in endGameLogics)
        {
            gle.Won();
        }
    }

    public void SubscribeItself(GameLogic gl)
    {
        gameLogics.Add(gl);
    }

    public void SubscribeItself(GameLogicEnd gle)
    {
        endGameLogics.Add(gle);
    }

}
