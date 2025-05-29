using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Prefabs.GravityEnabler
{
    public class GravityEnablerBehavior : ToolBehavior
    {
        private LineRenderer lineRenderer;
        private GameObject remoteRigidBody;

        public float maxDistance = 5f;
        public Material cannotMaterial;
        public Material canMaterial;
        public Material highlightMaterial;

        private Dictionary<Renderer, Material> modifiedObjects = new();

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            //ShowPointer();
        }

        private void ShowPointer()
        {
            if (lineRenderer)
            {
                lineRenderer.enabled = true;
            }
        }

        public override void OnTriggerAction(InputAction.CallbackContext context)
        {
            if (remoteRigidBody && context.performed)
            {
                Renderer rend = remoteRigidBody.GetComponent<Renderer>();
                Rigidbody rb = remoteRigidBody.GetComponent<Rigidbody>();

                if (rend && rb)
                {
                    rb.useGravity = !rb.useGravity;

                    if (!rb.useGravity)
                    {
                        if (!modifiedObjects.ContainsKey(rend))
                        {
                            modifiedObjects[rend] = rend.material;
                            rend.materials = new Material[] { rend.material, highlightMaterial };
                        }
                    }
                    else
                    {
                        if (modifiedObjects.ContainsKey(rend))
                        {
                            rend.materials = new Material[] { modifiedObjects[rend] };
                            modifiedObjects.Remove(rend);
                        }
                    }
                }
            }
        }

        public override void OnGripAction(InputAction.CallbackContext context) { }

        public override void OnAButtonAction(InputAction.CallbackContext context) { }

        public override void OnBButtonAction(InputAction.CallbackContext context) { }

        private void FixedUpdate()
        {
            if (lineRenderer)
            {
                lineRenderer.SetPosition(0, transform.position);

                RaycastHit hit;
                int layerMask = ~LayerMask.GetMask("Wall");
                if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
                {
                    lineRenderer.SetPosition(1, transform.position + transform.forward * hit.distance);

                    if (hit.collider.gameObject.CompareTag("Object"))
                    {
                        Rigidbody rb = hit.collider.gameObject.GetComponentInParent<Rigidbody>();
                        remoteRigidBody = rb.gameObject;
                        lineRenderer.material = canMaterial;
                    }
                    else
                    {
                        remoteRigidBody = null;
                        lineRenderer.material = cannotMaterial;
                    }
                }
                else
                {
                    lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
                    remoteRigidBody = null;
                    lineRenderer.material = cannotMaterial;
                }
            }
        }
    }
}
