using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation

    void Update()
    {
        // Rotate the object around its Y-axis every frame
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
