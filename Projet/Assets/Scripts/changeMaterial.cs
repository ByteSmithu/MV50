using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    // Matériaux à appliquer selon l'état
    public Material materialActivate;
    public Material materialDeactivate;

    // L'objet déclencheur attendu
    public GameObject correctTrigger;

    // Référence au Renderer du GameObject
    private Renderer meshRenderer;

    void Start()
    {
        // On récupère le Renderer attaché à ce GameObject
        meshRenderer = GetComponent<Renderer>();

        // On applique le matériau de base au démarrage
        if (materialDeactivate != null)
        {
            meshRenderer.material = materialDeactivate;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est le bon trigger
        if (correctTrigger != null && other.gameObject == correctTrigger)
        {
            if (materialActivate != null)
            {
                meshRenderer.material = materialActivate;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si l'objet sortant est le bon trigger, on remet le matériau d'origine
        if (correctTrigger != null && other.gameObject == correctTrigger)
        {
            if (materialDeactivate != null)
            {
                meshRenderer.material = materialDeactivate;
            }
        }
    }
}
