using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SmoothJumpWithoutBounciness : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 3.0f; // Movimiento horizontal
    public float jumpHeight = 5.0f; // Altura del salto
    public float gravity = -6.0f; // Gravedad reducida para caída más lenta (menos negativa)
    private Vector3 velocity; // Para manejar el movimiento vertical
    private bool isGrounded; // Para verificar si el jugador está en el suelo

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
        {
            Debug.LogError("No se encontró el componente CharacterController.");
        }
    }

    void Update()
    {
        // Verifica si el jugador está en el suelo
        isGrounded = characterController.isGrounded;

        if (isGrounded)
        {
            // Si el jugador está en el suelo, aseguramos que no haya rebote
            if (velocity.y < 0) // Solo si está cayendo
            {
                velocity.y = 0f; // Pone la velocidad vertical a 0 cuando toca el suelo
            }
        }

        // Movimiento horizontal utilizando el joystick
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 move = transform.forward * primaryAxis.y + transform.right * primaryAxis.x;
        characterController.Move(move * speed * Time.deltaTime);

        // Lógica del salto
        if (OVRInput.GetDown(OVRInput.Button.One) && isGrounded)
        {
            // Calcular la velocidad del salto basada en la altura deseada
            velocity.y = Mathf.Sqrt(2f * -gravity * jumpHeight); // Asegura que el jugador salte más alto
        }

        // Detener la velocidad en Y cuando se presiona el botón "X"
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            velocity.y = 0f; // Detener cualquier movimiento vertical cuando se presiona el botón X
        }

        // Aplicar la gravedad, ya que el jugador no está en el suelo
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime; // Aplicar gravedad normal cuando cae
        }

        // Mover al jugador considerando la velocidad vertical y horizontal
        characterController.Move(velocity * Time.deltaTime);
    }
}
