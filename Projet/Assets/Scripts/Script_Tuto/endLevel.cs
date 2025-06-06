using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private int checkEnd;
    private int nbrObjet;
    private AudioSource audioSource;
    // private bool endable;
    // private GameObject temp;


    void Start()
    {
        checkEnd = 4;
        // endable = false;
        audioSource = gameObject.GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {

     
        

    }

    // public void setNeeded()
    // {
    //     checkEnd = checkEnd + 1; 
    //     print(checkEnd);
    // }

    public void Increase()
    {
        checkEnd = checkEnd + 1;
        print(checkEnd);
        // print(endable);
    } 

        public void Decrease()
    {
        checkEnd = checkEnd - 1;
        print(checkEnd);
    }

    public void ifWin()
    {
        if (checkEnd == 0)
        {
            audioSource.Play(0);
            print(checkEnd);
            print("win");
        }       
    }
}
