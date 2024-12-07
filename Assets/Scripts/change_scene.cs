using UnityEngine;
using UnityEngine.SceneManagement;

public class CombinedTouchAndScoreHandler : MonoBehaviour
{
    public string sceneName;      // Name of the scene to load
    public string objectType;// Type of object to track (e.g., "abra", "pikachu")

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // **Update Score**
            int currentScore = PlayerPrefs.GetInt("Score", 0); // Get the current score (default 0 if not found)
            int updatedScore = currentScore + 1;              // Increment the score by 1
            PlayerPrefs.SetInt("Score", updatedScore);        // Save the updated score
            PlayerPrefs.Save();                              // Force save
            Debug.Log("Score incremented. New Score: " + updatedScore);

            // **Update Touched Objects**
            string touchedObjects = PlayerPrefs.GetString("TouchedObjects", ""); // Retrieve existing list
            PlayerPrefs.SetString("ObjectClicked", objectType);                  // Save the current object type

            if (!touchedObjects.Contains(objectType)) // Add the object if it's not already in the list
            {
                if (string.IsNullOrEmpty(touchedObjects))
                {
                    touchedObjects = objectType; // Start the list with this object
                }
                else
                {
                    touchedObjects += "," + objectType; // Append to the list
                }

                PlayerPrefs.SetString("TouchedObjects", touchedObjects); // Save the updated list
                PlayerPrefs.Save(); // Ensure changes are saved immediately
                Debug.Log("Object added to TouchedObjects list: " + objectType);
            }

            // **Load the Scene**
            if (!string.IsNullOrEmpty(sceneName)) // Ensure the scene name is set
            {
                SceneManager.LoadScene(sceneName); // Load the specified scene
            }
            else
            {
                Debug.LogError("Scene name is not set!");
            }
        }
    }
}