using UnityEngine;

namespace Prefabs.DistanceGrab
{
    [RequireComponent(typeof(Rigidbody))]
    public class DistanceGrabbedBehavior : MonoBehaviour
    {
        private Rigidbody rb;
        private bool grabbed = false;
        private bool wasGrav;

        private Vector3 lastPosition;
        private Vector3 currentVelocity;

        private Renderer objectRenderer;
        public Material highlightMaterial;

        private Material originalMaterial;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            objectRenderer = GetComponent<Renderer>();
            lastPosition = rb.position;

            if (objectRenderer != null)
            {
                originalMaterial = objectRenderer.material;
            }
        }

        private void FixedUpdate()
        {
            if (grabbed)
            {
                // Calculer vélocité selon déplacement physique réel
                Vector3 newPosition = rb.position;
                currentVelocity = (newPosition - lastPosition) / Time.fixedDeltaTime;
                lastPosition = newPosition;
                // Pas d'assignation de velocity ici, MovePosition gère le déplacement
            }
        }

        public void SetPosition(Vector3 newPos)
        {
            rb.MovePosition(newPos);
        }

        public bool isGrabbed()
        {
            return grabbed;
        }

        public void Grab()
        {
            grabbed = true;
            wasGrav = rb.useGravity;
            rb.useGravity = false;

            lastPosition = rb.position;

            if (objectRenderer != null && highlightMaterial != null)
            {
                Material[] newMats = new Material[2];
                newMats[0] = originalMaterial;
                newMats[1] = highlightMaterial;
                objectRenderer.materials = newMats;
            }
        }

        public void Release()
        {
            grabbed = false;
            rb.useGravity = wasGrav;

            // Appliquer la dernière vélocité pour conserver l'inertie
            rb.velocity = currentVelocity;

            if (objectRenderer != null)
            {
                objectRenderer.materials = new Material[] { originalMaterial };
            }
        }
    }
}
