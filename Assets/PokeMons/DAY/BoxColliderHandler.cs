using UnityEngine;

public class BoxColliderHandler : MonoBehaviour
{
    private BoxCollider boxCollider;

    void Start()
    {
        // Obtener el componente BoxCollider
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogError("No se encontró un BoxCollider en este objeto.");
            return;
        }

        // Asegurarse de que inicialmente no sea un trigger
        boxCollider.isTrigger = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("pokeball"))
        {
            Debug.Log("Colisión detectada con el jugador. Activando 'Is Trigger'.");

            // Activar la opción de "Is Trigger"
            boxCollider.isTrigger = true;
        }
        else
        {
            boxCollider.isTrigger = false;
        }
    }
}
