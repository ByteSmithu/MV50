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
        SideEffect();
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == gameObjectToCollideWith)
            conditionDone = false;
        ReverseSideEffect();
    }


    public override bool IsGameLogicTrue()
    {
        return conditionDone;
    }
    
    public override void SideEffect(){}
    public override void ReverseSideEffect(){}
}
