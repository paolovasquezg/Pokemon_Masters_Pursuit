using UnityEngine;
using UnityEngine.SceneManagement; // Include SceneManager namespace

public class PlayerPrefsExample : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    void Start()
    {
        // Set the "Score" PlayerPrefs key to 0
        PlayerPrefs.SetInt("Score", 0);
        Debug.Log("Score set to 0");

        // Jump to the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
