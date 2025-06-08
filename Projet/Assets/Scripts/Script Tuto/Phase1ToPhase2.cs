using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1ToPhase2 : MonoBehaviour
{
    public GameObject oldPhaseObject;
    public GameObject newPhaseObject;

    public AudioSource sound;

    private Transform oldTran;
    private Transform newTran;

    private Vector3 temp; 

    public Material bleu;
    public Material rouge;
    public Material vert;
    public Material jaune;
    
    public GameObject planBleu;
    public GameObject planRouge;
    public GameObject planVert;
    public GameObject planJaune;


    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        oldTran = oldPhaseObject.GetComponent<Transform> ();
        newTran = newPhaseObject.GetComponent<Transform> ();

        temp = oldTran.position;

    }



    private IEnumerator bringPhase2()
    {
        yield return new WaitForSeconds(sound.clip.length + 2);
        newTran.position = temp;
        print("here");
        planBleu.GetComponent<MeshRenderer>().material = bleu;
        planRouge.GetComponent<MeshRenderer>().material = rouge;
        planJaune.GetComponent<MeshRenderer>().material = jaune;
        planVert.GetComponent<MeshRenderer>().material = vert;

    }

    

    void OnTriggerEnter(Collider other)
    {
        
        oldTran.position = new Vector3(100,0,100);
        sound.Play(0);
        StartCoroutine(bringPhase2());

    }


}
