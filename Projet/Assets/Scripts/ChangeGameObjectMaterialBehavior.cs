using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameObjectMaterialBehavior : MonoBehaviour
{
    public GameObject gameObjectToToggle;
    public Material togglableMaterial; 
    
    public void Toggle()
    {
        if (gameObjectToToggle)
        {
            if (togglableMaterial)
            {
                List<Material> materials = new List<Material>();
                gameObjectToToggle.GetComponent<MeshRenderer>().GetMaterials(materials);
                (materials[0], togglableMaterial) = (togglableMaterial, materials[0]);
                gameObjectToToggle.GetComponent<MeshRenderer>().SetMaterials(materials);
            }
        }
    }
}
