using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefabs.DistanceGrab
{
    public class DistanceGrabGhostLimiter : MonoBehaviour
    {
        private DistanceGrabBehavior grabBehavior;
        public Transform[] ghostPoints;
        public float snapDistanceThreshold = 0.5f;

        private void Awake()
        {
            grabBehavior = GetComponent<DistanceGrabBehavior>();
            Debug.Log("[GhostLimiter] Awake: grabBehavior " + (grabBehavior != null ? "found" : "NOT found"));
        }

        private void FixedUpdate()
        {
            if (grabBehavior != null && grabBehavior.IsGrabbing())
            {
                Debug.Log("[GhostLimiter] Is grabbing an object.");
                GameObject grabbedObject = grabBehavior.GetGrabbedObject();
                if (grabbedObject != null && ghostPoints.Length > 0)
                {
                    Vector3 targetDirection = transform.forward;
                    float transformDistance = grabBehavior.GetTransformDistance();
                    Vector3 targetPos = transform.position + targetDirection * transformDistance;
                    Debug.Log($"[GhostLimiter] Target position from grabBehavior: {targetPos} (distance {transformDistance})");

                    Transform closestGhost = null;
                    float minDist = Mathf.Infinity;

                    foreach (Transform ghost in ghostPoints)
                    {
                        if (ghost.CompareTag("Ghosts"))
                        {
                            float dist = Vector3.Distance(targetPos, ghost.position);
                            Debug.Log($"[GhostLimiter] Checking ghost {ghost.name} at {ghost.position}, distance to target: {dist}");
                            if (dist < minDist && dist <= snapDistanceThreshold)
                            {
                                minDist = dist;
                                closestGhost = ghost;
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"[GhostLimiter] Ghost point {ghost.name} does NOT have tag 'Ghost'");
                        }
                    }

                    if (closestGhost != null)
                    {
                        Debug.Log($"[GhostLimiter] Closest ghost found: {closestGhost.name} at distance {minDist}, snapping object.");
                        DistanceGrabbedBehavior dgb = grabbedObject.GetComponent<DistanceGrabbedBehavior>();
                        if (dgb != null)
                        {
                            dgb.SetPosition(closestGhost.position);
                        }
                        else
                        {
                            Debug.LogWarning("[GhostLimiter] Grabbed object does not have DistanceGrabbedBehavior component.");
                        }
                    }
                    else
                    {
                        Debug.Log("[GhostLimiter] No ghost close enough to snap to.");
                    }
                }
                else
                {
                    Debug.LogWarning("[GhostLimiter] No grabbed object or no ghosts defined.");
                }
            }
            else
            {
                Debug.Log("[GhostLimiter] Not grabbing currently or grabBehavior missing.");
            }
        }
    }
}
