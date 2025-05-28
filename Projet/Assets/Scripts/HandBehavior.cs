    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandBehavior : MonoBehaviour
{
    public Animator rightHandAnimator;
    public Animator leftHandAnimator;
    void Start()
    {
        
    }

    public void OnLeftGripAxis(InputAction.CallbackContext context)
    {
        if (leftHandAnimator){
            leftHandAnimator.SetFloat("Close", context.ReadValue<float>());
        }
    }
    public void OnRightGripAxis(InputAction.CallbackContext context)
    {
        if (rightHandAnimator)
        {
            rightHandAnimator.SetFloat("Close", context.ReadValue<float>());
        }
    }
    public void OnLeftTriggerTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (leftHandAnimator)
            {
                leftHandAnimator.SetBool("Point", false);
            }
        }
        if (context.canceled)
        {
            if (leftHandAnimator)
            {
                leftHandAnimator.SetBool("Point", true);
            }
        }
    }
    public void OnRightTriggerTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rightHandAnimator)
            {
                rightHandAnimator.SetBool("Point", false);
            } 
        }
        if (context.canceled)
        {
            if (rightHandAnimator)
            {
                rightHandAnimator.SetBool("Point", true);
            } 
        }
    }
}
