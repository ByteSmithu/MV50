using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{
    public List<GameObject> gameLogicsHost = new List<GameObject>();
    public List<GameObject> endGameLogicsHost = new List<GameObject>();
    private List<GameLogic> gameLogics = new List<GameLogic>();
    private List<GameLogicEnd> endGameLogics = new List<GameLogicEnd>();

    public void Start()
    {
        foreach (GameObject go in gameLogicsHost)
        {
            gameLogics.Add(go.GetComponent<GameLogic>());
        }

        foreach (GameObject go in endGameLogicsHost)
        {
            endGameLogics.Add(go.GetComponent<GameLogicEnd>());
        }
    }

    private void Update()
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

    public void addGameLogic(GameObject go)
    {
        gameLogicsHost.Add(go);
        gameLogics.Add(go.GetComponent<GameLogic>());
    }

    public void removeGameLogic(GameObject go)
    {
        gameLogicsHost.Remove(go);
        gameLogics.Remove(go.GetComponent<GameLogic>());
    }
    
    public void addEndGameLogic(GameObject go)
    {
        endGameLogicsHost.Add(go);
        endGameLogics.Add(go.GetComponent<GameLogicEnd>());
    }

    public void removeEndGameLogic(GameObject go)
    {
        endGameLogicsHost.Remove(go);
        endGameLogics.Remove(go.GetComponent<GameLogicEnd>());
    }
}
