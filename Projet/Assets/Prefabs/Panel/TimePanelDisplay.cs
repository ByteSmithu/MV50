using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPanelDisplay : MonoBehaviour
{
    public GameObject panel;     
    public float displayTime;

    private void Start()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            Invoke(nameof(HidePanel), displayTime); 
        }
    }

    private void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);  
        }
    }
}
