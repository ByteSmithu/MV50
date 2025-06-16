using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class GravityHaptics : MonoBehaviour
{
    public float amplitude = 1f; // Intensité de la vibration (0.0 à 1.0)
    public float duration = 0.3f;  // Durée en secondes

    private List<InputDevice> devices = new List<InputDevice>();
    
    private InputDevice leftHand;
    private InputDevice rightHand;


    void Update()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);

        foreach (var device in allDevices)
        {
            if ((device.characteristics & InputDeviceCharacteristics.Left) != 0)
            {
                leftHand = device;
            }

            if ((device.characteristics & InputDeviceCharacteristics.Right) != 0)
            {
                rightHand = device;
            }
    }


    }
    public void TriggerDirectionalHaptics()
    {
        Vector3 gravityDir = Physics.gravity.normalized;

        float leftIntensity = Mathf.Clamp01(-gravityDir.x);  // vers la gauche
        float rightIntensity = Mathf.Clamp01(gravityDir.x);  // vers la droite
        Debug.Log(leftIntensity);
        Debug.Log(rightIntensity);
        if (leftIntensity < 0.1f && rightIntensity < 0.1f)
        {
            leftIntensity += 0.1f;
            rightIntensity += 0.1f;
            if (leftHand.isValid && leftHand.TryGetHapticCapabilities(out var leftCap) && leftCap.supportsImpulse)
            {
                leftHand.SendHapticImpulse(0,leftIntensity * amplitude, duration);
            }

            if (rightHand.isValid && rightHand.TryGetHapticCapabilities(out var rightCap) && rightCap.supportsImpulse)
            {
                rightHand.SendHapticImpulse(0, rightIntensity * amplitude, duration);
            }
        }
        else
        {
            if (leftHand.isValid && leftHand.TryGetHapticCapabilities(out var leftCap) && leftCap.supportsImpulse)
            {
                leftHand.SendHapticImpulse(0, leftIntensity * amplitude, duration);
            }

            if (rightHand.isValid && rightHand.TryGetHapticCapabilities(out var rightCap) && rightCap.supportsImpulse)
            {
                rightHand.SendHapticImpulse(0, rightIntensity * amplitude, duration);
            }
        }
        
    }

}