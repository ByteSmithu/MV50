using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjectOnWin : GameLogicEnd
{
    public GameObject toActivate;
    
    public override void Won()
    {
        toActivate.SetActive(true);
    }
}
