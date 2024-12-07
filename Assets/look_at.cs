using UnityEngine;

public class PointXAxisAtTarget : MonoBehaviour
{
    public Transform target; // The object to point at

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;

            // Create a rotation where the X-axis points to the target
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // Rotate the object so the X-axis points toward the target
            transform.rotation = rotation * Quaternion.Euler(0, 90, 0); // Adjust -90 degrees
        }
    }
}