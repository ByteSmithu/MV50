using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneShowPanel : MonoBehaviour
{
    public GameObject winPanel; 

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true);  
            }
        }
    }
}
