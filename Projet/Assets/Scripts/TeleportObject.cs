using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Le but de cette classe est de gérer la téléportation d'objet quand un trigger est activé
//Il faut appliquer ce script à l'objet qui contient le trigger
public class TeleportObject : MonoBehaviour
{
    // On stock la position désiré après téléportation en ce basant sur les coordoné global
    public Vector3 destination;

    // On choisi la cible à téléporter
    public GameObject objetTeleporte;

    private Transform tran; 

    // Start is called before the first frame update
    void Start()
    {
        tran = objetTeleporte.GetComponent<Transform> ();        


    }



    void OnTriggerEnter(Collider other)
    {
        tran.position = destination;
    }


}
