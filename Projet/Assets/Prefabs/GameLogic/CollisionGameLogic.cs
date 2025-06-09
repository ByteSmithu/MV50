using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGameLogic : GameLogic
{
    public GameObject gameObjectToCollideWith;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == gameObjectToCollideWith)
            conditionDone = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == gameObjectToCollideWith)
            conditionDone = false;
    }


    public override bool IsGameLogicTrue()
    {
        return conditionDone;
    }
}
