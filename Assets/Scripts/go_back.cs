using UnityEngine;
using UnityEngine.SceneManagement; // To load scenes

public class LoadSceneOnButtonPress : MonoBehaviour
{
    public string sceneName = "NewScene"; // Name of the scene to load

    void Update()
    {
        // Check if the "X" button is pressed on the Oculus controller
        if (OVRInput.GetDown(OVRInput.Button.Three)) // Button.One corresponds to the "X" button on the Oculus controller
        {
            // Load the specified scene
            LoadScene();
        }
    }

    // Method to load the scene
    void LoadScene()
    {
        // Make sure the scene name is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName); // Load the scene
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}
