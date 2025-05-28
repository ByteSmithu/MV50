using UnityEngine;
using UnityEngine.InputSystem;

namespace Prefabs.Gravity
{
    public class GravityBehavior : ToolBehavior
    {
        private LineRenderer lineRenderer;
        private Vector3 pos;
        private bool reverse = false;
        private float length = 0;
        public float stengthMultiplier = 4f; // multiplicateur de la force de gravité indispensable pour avoir une gravité raisonnable sans des traits de 10 mètres
        public float rate = 0.2f; // vitesse à laquelle la force s'accroit

        
        private bool pointerVisible;
        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            HidePointer();
        }
    
        private void ShowPointer()
        {
            pointerVisible = true;
            ActualizeLine();
        }

        private void HidePointer()
        {
            pointerVisible = false;
            ActualizeLine();
        }

        private void ActualizeLine()
        {
            if (lineRenderer)
            {
                lineRenderer.enabled = pointerVisible;
            }
        }

        public override void OnTriggerAction(InputAction.CallbackContext context)
        {
            if (isActive())
            {
                if (context.started)
                {
                    ShowPointer();
                    length = 0;
                }

                if (context.canceled)
                {
                    HidePointer();
                    ChangeGravity();
                }
            }
        }

        public override void OnGripAction(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                reverse = true;
            }

            if (context.canceled)
            {
                reverse = false;
            }
        }

        public override void OnAButtonAction(InputAction.CallbackContext context)
        {
        }

        public override void OnBButtonAction(InputAction.CallbackContext context)
        {
        }


        public void FixedUpdate()
        {
            if (pointerVisible)
            {
                length += Time.fixedDeltaTime * rate;
                pos = transform.position;
                lineRenderer.SetPosition(0,pos);
                pos += length * transform.TransformDirection(Vector3.forward);
                lineRenderer.SetPosition(1,pos);
            }
        }

        public void ChangeGravity()
        {
            Vector3 start = lineRenderer.GetPosition(0);
            Vector3 end = lineRenderer.GetPosition(1);
            Vector3 vect = end - start;
            if (reverse) vect *= -1;
            Physics.gravity = vect*stengthMultiplier;

        }
    }
}
