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
    private Transform cubeTran;

    public Material bleu;
    public Material rouge;
    public Material vert;
    public Material jaune;
    
    public GameObject planBleu;
    public GameObject planRouge;
    public GameObject planVert;
    public GameObject planJaune;
    public GameObject cube;


    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        oldTran = oldPhaseObject.GetComponent<Transform>();
        newTran = newPhaseObject.GetComponent<Transform>();
        cubeTran = cube.GetComponent<Transform>();

    }



    private IEnumerator bringPhase2()
    {
        oldTran.position = new Vector3(100,0,100);
        yield return new WaitForSeconds(sound.clip.length + 1);
        cubeTran.position = new Vector3(100,0,100);

        newTran.position = new Vector3(0,0,0);
        planBleu.GetComponent<MeshRenderer>().material = bleu;
        planRouge.GetComponent<MeshRenderer>().material = rouge;
        planJaune.GetComponent<MeshRenderer>().material = jaune;
        planVert.GetComponent<MeshRenderer>().material = vert;

    }

    

    void OnTriggerEnter(Collider other)
    {
        sound.Play(0);
        StartCoroutine(bringPhase2());

    }


}
