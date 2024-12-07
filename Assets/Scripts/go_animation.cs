using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnTrigger : MonoBehaviour
{
    public string sceneName;  // Name of the scene to load
    public string objectType; // Type of object to pass (e.g., "Frog", "Rabbit")

    void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "pokeball" or "Player" tag
        if (other.CompareTag("pokeball") || other.CompareTag("Player"))
        {
            // Save the object type to PlayerPrefs (this could be frog or rabbit)
            PlayerPrefs.SetString("ObjectClicked", objectType);

            // Load the next scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
