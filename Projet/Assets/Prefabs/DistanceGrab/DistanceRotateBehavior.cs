using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefabs.DistanceGrab
{
    public class DistanceRotatedBehavior : MonoBehaviour
    {
        private bool isRotating = false;
        private Renderer objectRenderer;
        public Material highlightMaterial;
        private Material originalMaterial;
        private Quaternion initialRotation;


        private void Start()
        {

            objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                originalMaterial = objectRenderer.material;
            }
        }

        public void Rotation()
        {
            isRotating = true;
            initialRotation = transform.rotation;

            if (objectRenderer != null && highlightMaterial != null)
            {
                Material[] newMats = new Material[2];
                newMats[0] = originalMaterial;
                newMats[1] = highlightMaterial;
                objectRenderer.materials = newMats;
            }
        }

        public void ApplyRotation(float deltaX, float sensitivity)
        {
            if (!isRotating) return;

            float angle = deltaX * sensitivity * 360f;

            transform.rotation = initialRotation * Quaternion.Euler(0f, -angle, 0f);
        }


        public void Release()
        {
            isRotating = false;

            if (objectRenderer != null)
            {
                objectRenderer.materials = new Material[] { originalMaterial };
            }
        }
    }
}
