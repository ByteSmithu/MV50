using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitToPhase1 : MonoBehaviour
{
    
    public AudioSource sound;


    private Transform Tran;
    public GameObject Object;

    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        Tran = Object.GetComponent<Transform>();
        
        sound.Play(0);
        StartCoroutine(bringPhase1());

    }

    private IEnumerator bringPhase1()
    {
        yield return new WaitForSeconds(sound.clip.length);
        Tran.position = new Vector3(0,0,0);;
        print("here");

    }
}
