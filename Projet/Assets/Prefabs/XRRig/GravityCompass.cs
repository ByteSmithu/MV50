using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GravityCompass : MonoBehaviour
{
    public float minGravity = 0f;
    public float maxGravity = 10f; 
    public Material compassMaterial;

    void Update()
    {
        float gravityStrength = Physics.gravity.magnitude;

        float gravityPower = Mathf.InverseLerp(minGravity, maxGravity, gravityStrength);

        compassMaterial.SetFloat("_GravityPower", gravityPower);
    }
}
