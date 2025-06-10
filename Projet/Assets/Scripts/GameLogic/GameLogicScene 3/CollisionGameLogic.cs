using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionGameLogic : GameLogic
{
    public GameObject gameObjectToCollideWith;
    public Material color;
    private Material oldColor;

    public new void Start()
    {
        base.Start();
        oldColor = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject == gameObjectToCollideWith)
        {
            conditionDone = true;
            SideEffect();
            NotifyManager();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == gameObjectToCollideWith)
        {
            conditionDone = false;
            ReverseSideEffect();
            NotifyManager();
        }
    }


    public override bool IsGameLogicTrue()
    {
        return conditionDone;
    }

    public override void SideEffect()
    {
        gameObject.GetComponent<MeshRenderer>().material = color;
    }

    public override void ReverseSideEffect()
    {
        gameObject.GetComponent<MeshRenderer>().material = oldColor;
    }
}