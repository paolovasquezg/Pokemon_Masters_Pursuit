using UnityEngine;

public class TeleportAndStop : MonoBehaviour
{
    private Vector3 initialPosition; // Initial position of the object
    private Rigidbody rb;            // Rigidbody component of the object
    private bool isHeld = false;     // Flag to check if the object is held
    private float timer = 0f;        // Timer to track time before teleporting

    public OVRInput.Controller controller; // Specify which controller you're using for tracking

    void Start()
    {
        initialPosition = transform.position; // Save initial position
        rb = GetComponent<Rigidbody>(); // Get Rigidbody
    }

    void Update()
    {
        // Check if the object is held (e.g., using the hand trigger as input)
        isHeld = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller);

        // Reset the timer if the object is being held
        if (isHeld)
        {
            timer = 0f; // Reset the timer
        }
        else
        {
            // Increment timer if not held
            timer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Only teleport if the timer exceeds 5 seconds and the object is not held
        if (!isHeld && timer >= 10f)
        {
            TeleportAndStopObject();
            timer = 0f; // Reset timer after teleportation
        }
    }

    void TeleportAndStopObject()
    {
        // Teleport to initial position and stop movement
        transform.position = initialPosition;

        // If Rigidbody exists, stop its movement
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Stop velocity
            rb.angularVelocity = Vector3.zero; // Stop angular velocity
        }

        Debug.Log("Object teleported back to the initial position.");
    }
}
