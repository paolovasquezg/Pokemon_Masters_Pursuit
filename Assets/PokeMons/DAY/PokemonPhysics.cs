using UnityEngine;

public class PokemonPhysics : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 300f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * rb.mass * 4); // Aumentar la gravedad
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
