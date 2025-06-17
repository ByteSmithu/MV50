
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using System.Collections.Generic;
using TMPro;


public class RaycastInteractor : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Button targetButton;

    public float maxDistance = 10f;
    public Material canClickMaterial;
    public GravityHaptics gravityHaptics;
    public bool isLeftHand;
    private UnityEngine.XR.InputDevice device; // specifie pour eviter le conflit entre utilsiation de InputSystem et XR
    public ChangeSceneOnWin changeScene;
    public bool isEnd;
    private TextMeshProUGUI sceneName;
    private bool isTeleporting = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = canClickMaterial;
    }

    public void OnTriggerAction(InputAction.CallbackContext context)
    {
        if (targetButton != null && context.performed && !isTeleporting)
        {
            // Déclencher la vibration sur la bonne main
            gravityHaptics.TriggerHaptics(isLeftHand);
            if (!isEnd)
            {
                changeScene.Won();
            }
            else
            {
                sceneName = targetButton.GetComponentInChildren<TextMeshProUGUI>();
                changeScene.TransitionToSceneFromText(sceneName.text);
            }
            isTeleporting = true;
        }
    }

        private void FixedUpdate()
        {
            if (!lineRenderer) return;

            lineRenderer.SetPosition(0, transform.position);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * hit.distance);

                Button button = hit.collider.GetComponent<Button>();
                if (button != null)
                {
                    targetButton = button;
                }
                else
                {
                    targetButton = null;
                }
            }
            else
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
                targetButton = null;
            }
        }
}

