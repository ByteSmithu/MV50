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

        public GravityHaptics gravityHaptics;

        public bool isLeftHand;

        public AudioSource sound;

        private void Start()
        {
            sound = gameObject.GetComponent<AudioSource>();


            lineRenderer = GetComponent<LineRenderer>();
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
                    sound.Play(0);
                    gravityHaptics.TriggerHaptics(isLeftHand);
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
