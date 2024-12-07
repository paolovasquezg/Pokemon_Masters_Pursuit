using UnityEngine;
using UnityEngine.SceneManagement;

public class PokemonTouchHandler : MonoBehaviour
{
    public string sceneName;  // Name of the scene to load
    public string objectType; // Type of object to pass (e.g., "abra", "pikachu")

    void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "pokeball" or "Player" tag
        if (other.CompareTag("Player"))
        {
            // Retrieve the current list of touched objects from PlayerPrefs
            string touchedObjects = PlayerPrefs.GetString("TouchedObjects", "");
            PlayerPrefs.SetString("ObjectClicked", objectType);

            // Add the current object's name to the list (if it's not already in the list)
            if (!touchedObjects.Contains(objectType))
            {
                if (string.IsNullOrEmpty(touchedObjects))
                {
                    touchedObjects = objectType;  // Start the list with the first object
                }
                else
                {
                    touchedObjects += "," + objectType;  // Append to the list
                }

                // Save the updated list back to PlayerPrefs
                PlayerPrefs.SetString("TouchedObjects", touchedObjects);
                PlayerPrefs.Save();  // Save PlayerPrefs immediately
            }

            // Load the next scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
