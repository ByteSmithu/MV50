using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameLogic : MonoBehaviour
{
    protected bool conditionDone;
    public abstract bool IsGameLogicTrue();
}
