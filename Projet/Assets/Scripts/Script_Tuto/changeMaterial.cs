using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMaterial : MonoBehaviour
{

    public Material MaterialActivate;
    private Material MaterialDeactivate;

    private endLevel endLevelScript;

    public GameObject correctTrigger = null;

    private MeshRenderer mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer> ();

        MaterialDeactivate = mesh.material;
        endLevelScript = GameObject.FindGameObjectWithTag("endLevelTag").GetComponent<endLevel>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) 
    {
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
