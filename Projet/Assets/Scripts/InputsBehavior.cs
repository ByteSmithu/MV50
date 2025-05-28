using UnityEngine.InputSystem;
using UnityEngine;

public class InputsBehavior : MonoBehaviour
{
    public Animator rightAnimator;
    public Animator leftAnimator;
    public GameObject rightThumbstick;
    public GameObject leftThumbstick;
    Vector3 leftStartAngles;

    void Start(){
        if(leftThumbstick)
            leftStartAngles = leftThumbstick.transform.localEulerAngles;
    }

    public void OnAPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rightAnimator)
            {
                rightAnimator.SetBool("APressed", true);

            }
        }
            if (context.canceled)
        {
            if (rightAnimator)
            {
                rightAnimator.SetBool("APressed", false);
            }
        }
     }
    public void OnBPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rightAnimator)
            {
                rightAnimator.SetBool("BPressed", true);
            }
        }
            if (context.canceled)
        {
            if (rightAnimator)
            {
                rightAnimator.SetBool("BPressed", false);
            }
        }
     }

     public void OnXPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (leftAnimator)
            {
                leftAnimator.SetBool("XPressed", true);

            }
        }
            if (context.canceled)
        {
            if (leftAnimator)
            {
                leftAnimator.SetBool("XPressed", false);
            }
        }
     }
    public void OnYPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (leftAnimator)
            {
                leftAnimator.SetBool("YPressed", true);
            }
        }
            if (context.canceled)
        {
            if (leftAnimator)
            {
                leftAnimator.SetBool("YPressed", false);
            }
        }
     }

    public void OnRightTriggerAxis(InputAction.CallbackContext context)
    {
        if (rightAnimator)
        {
            rightAnimator.SetFloat("RightTrigger", context.ReadValue<float>());
        }
    }

    public void OnLeftTriggerAxis(InputAction.CallbackContext context)
    {
        if (leftAnimator)
        {
            leftAnimator.SetFloat("LeftTrigger", context.ReadValue<float>());
        }
    }


    public void OnRightThumbstickAxis(InputAction.CallbackContext context)
    {
        if (rightThumbstick)
        {
            Vector2 rightThumbstickValue = context.ReadValue<Vector2>();
            rightThumbstick.transform.localEulerAngles = new Vector3(rightThumbstickValue.y, 0, -rightThumbstickValue.x) * 15f;
        }
    }

public void OnLeftThumbstickAxis(InputAction.CallbackContext context)
{
    if (leftThumbstick)
    {
        Vector2 leftThumbstickValue = context.ReadValue<Vector2>();
        Vector3 offset = new Vector3(leftThumbstickValue.x, 0, leftThumbstickValue.y) * 15f;
        leftThumbstick.transform.localEulerAngles = leftStartAngles + offset;
    }
}




}