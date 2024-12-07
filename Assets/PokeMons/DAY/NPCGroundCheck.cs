using UnityEngine;

public class NPCGroundCheck : MonoBehaviour
{
    public float groundOffset = 0.1f; // Ajuste de altura desde el suelo
    public LayerMask groundLayer; // Capa del suelo

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el NPC está cerca del suelo
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            // Ajustar la posición del NPC para mantenerlo sobre el suelo
            Vector3 targetPosition = new Vector3(transform.position.x, hit.point.y + groundOffset, transform.position.z);
            transform.position = targetPosition;
        }
    }
}
