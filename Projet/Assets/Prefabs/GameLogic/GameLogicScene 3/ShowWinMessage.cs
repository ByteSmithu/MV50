using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWinMessage : GameLogicEnd
{

    public new void Start()
    {
        base.Start();
        gameObject.SetActive(false);
    }
    public override void Won()
    {
        gameObject.SetActive(true);
    }
}
