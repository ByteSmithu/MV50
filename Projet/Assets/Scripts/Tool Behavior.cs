using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ToolBehavior : MonoBehaviour
{
    private bool active = false;

    public void activate()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }

    public bool isActive()
    {
        return active;
    }

    public abstract void OnTriggerAction(InputAction.CallbackContext context);

    public abstract void OnGripAction(InputAction.CallbackContext context);

    public abstract void OnAButtonAction(InputAction.CallbackContext context);

    public abstract void OnBButtonAction(InputAction.CallbackContext context);


}
