using UnityEngine;
using UnityEngine.InputSystem;

namespace Prefabs.DistanceGrab
{
    public class DistanceGrabBehavior : ToolBehavior
    {
        private LineRenderer lineRenderer;
        private bool grabbing = false;
        private bool isBox = false;
        private bool isRotating = false;
        private GameObject grabbedGameObject;
        private GameObject tempGrabbedGameObject;
        private float hitDistance;
        private float transformDistance;

        public float maxDistance = 5f;
        public Material cannotMaterial;
        public Material canMaterial;

        private float initialControllerX;
        public float rotationSensitivity; 
        public Transform controllerTransform;

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
            if (isActive())
            {
                if (context.started)
                {
                    GrabOject();
                }

                if (context.canceled)
                {
                    releaseObject();
                }
            }
        }

        public override void OnGripAction(InputAction.CallbackContext context)
        {
            
        }

        public override void OnAButtonAction(InputAction.CallbackContext context)
        {
        }

        public override void OnBButtonAction(InputAction.CallbackContext context)
        {
        }

        private void GrabOject()
        {
            

            if (tempGrabbedGameObject != null)
            {
                if (isBox)
                {
                    isRotating = true;
                    DistanceRotatedBehavior drb = tempGrabbedGameObject.GetComponent<DistanceRotatedBehavior>();
                    grabbedGameObject = tempGrabbedGameObject;
                    tempGrabbedGameObject = null;
                    drb.Rotation();
                    initialControllerX = controllerTransform.position.x;
                }
                else
                {
                    DistanceGrabbedBehavior dgb = tempGrabbedGameObject.GetComponent<DistanceGrabbedBehavior>();
                    if (!dgb.isGrabbed())
                    {
                        grabbedGameObject = tempGrabbedGameObject;
                        grabbing = true;
                        tempGrabbedGameObject = null;
                        dgb.Grab();
                    }   
                }

            }
        }
        private void releaseObject()
        {
            if (grabbing)
            {
                grabbedGameObject.GetComponent<DistanceGrabbedBehavior>().Release();
                grabbedGameObject = null;
                grabbing = false;
            }
            if (isRotating)
            {
                grabbedGameObject.GetComponent<DistanceRotatedBehavior>().Release();
                grabbedGameObject = null;
                isRotating = false;
            }
        }


        void FixedUpdate()
        {
            if (lineRenderer)
            {
                lineRenderer.SetPosition(0, transform.position);
                if (!grabbing && !isRotating)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                            maxDistance))
                    {
                        lineRenderer.SetPosition(1, transform.position + transform.forward * hit.distance);

                        DistanceGrabbedBehavior dgb = hit.collider.gameObject.GetComponentInParent<DistanceGrabbedBehavior>();

                        if (dgb)
                        {

                            tempGrabbedGameObject = dgb.gameObject;
                            lineRenderer.material = canMaterial;
                            hitDistance = hit.distance;
                            transformDistance = ((hit.point - transform.position) +
                                                 (tempGrabbedGameObject.transform.position - hit.point))
                                .magnitude;
                        }
                        else
                        {
                            tempGrabbedGameObject = null;
                            lineRenderer.material = cannotMaterial;
                        }

                        if (hit.collider.gameObject.CompareTag("Box"))
                        {
                            isBox = true;
                            tempGrabbedGameObject = hit.collider.gameObject.transform.parent.gameObject;
                            lineRenderer.material = canMaterial;
                            hitDistance = hit.distance;
                            transformDistance = ((hit.point - transform.position) +
                                                 (hit.collider.gameObject.transform.position - hit.point))
                                .magnitude;
                        }
                        else
                        {
                            isBox = false;
                        }
                        
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
                        tempGrabbedGameObject = null;
                        lineRenderer.material = cannotMaterial;
                    }
                }

                else
                {
                    lineRenderer.SetPosition(1, transform.position + transform.forward * transformDistance);
                
                    if (isRotating && grabbedGameObject != null)
                    {
                        float deltaX = controllerTransform.position.x - initialControllerX;
                        grabbedGameObject.GetComponent<DistanceRotatedBehavior>().ApplyRotation(deltaX, rotationSensitivity);
                    }
                    else
                    {
                        //retravailler
                        DistanceGrabbedBehavior dgb = grabbedGameObject.GetComponent<DistanceGrabbedBehavior>();
                        if (dgb)
                        {
                            Vector3 currentPos = dgb.transform.position;
                            Vector3 targetPos = transform.position + transform.forward * transformDistance;
                            float threshold = 0.01f;

                            Vector3 direction = (targetPos - currentPos).normalized;
                            float distance = Vector3.Distance(currentPos, targetPos);

                            // Raycast pour voir s'il y a un mur entre la position actuelle et la cible
                            if (Physics.Raycast(currentPos, direction, out RaycastHit hit, distance))
                            {
                                if (hit.collider.CompareTag("Wall"))
                                {
                                    // Mur détecté : on bloque le mouvement (ne bouge pas)
                                    lineRenderer.SetPosition(1, hit.point);
                                    Debug.Log("Mur détecté : mouvement bloqué");
                                    return;
                                }
                            }


                            if (distance > threshold)
                            {
                                dgb.SetPosition(targetPos);
                                lineRenderer.SetPosition(1, targetPos);
                            }
                        }
                    }


                }

            }
        }
    }
}