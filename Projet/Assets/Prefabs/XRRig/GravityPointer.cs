using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointer : MonoBehaviour
{
    void Update()
    {
        Vector3 gravityDirection = Physics.gravity.normalized;
        transform.rotation = Quaternion.LookRotation(gravityDirection);
 
    }

}
