using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMaterial : MonoBehaviour
{

    //On crée deux instance de matériaux, une pour le materiaux si le bloc est sur la bonne surface, l'autre pour le matériaux d'origine 
    public Material MaterialActivate;
    private Material MaterialDeactivate;

    //On crée une instance du script endLevel afin de pouvoir gérer la fin du niveau
    private endLevel endLevelScript;

    //On crée une instance de GameObject public afin de pouvoir définir sur quel face le bloc doit aller 
    public GameObject correctTrigger = null;

    //Pour pouvoir changer le materiel de façon dynamique il faut une instance de MeshRender
    private MeshRenderer mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        //On stock le materiel d'origine 
        mesh = this.gameObject.GetComponent<MeshRenderer> ();
        MaterialDeactivate = mesh.material;

        //On connecte le script "endLevel"
        endLevelScript = GameObject.FindGameObjectWithTag("endLevelTag").GetComponent<endLevel>();

    }

    //On surveille si un bloc entre dans la zone de trigger d'un autre objet 

    void OnTriggerEnter(Collider other) 
    {
        //On vérifie si le trigger dans lequel le bloc vient de rentrer est celui que l'on attend ou non
        if(other.gameObject.name == correctTrigger.name)
        {
            mesh.material = MaterialActivate;
            endLevelScript.Decrease();      
            endLevelScript.ifWin();  

        }
    }

    void OnTriggerExit(Collider other)
    {
        mesh.material = MaterialDeactivate;
        if(other.gameObject.name == correctTrigger.name)
        {            
            endLevelScript.Increase();

        }
    }
}
