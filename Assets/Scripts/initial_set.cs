using UnityEngine;
using UnityEngine.SceneManagement; // Include SceneManager namespace

public class ResetGameProgress : MonoBehaviour
{
    public int initialScore;  // Value to set the "Score" to

    void Start()
    {
        // Reset the "TouchedObjects" list in PlayerPrefs to empty
        PlayerPrefs.SetString("TouchedObjects", "");
        Debug.Log("Touched objects list reset.");

        // Set the "Score" to the specified initial value
        PlayerPrefs.SetInt("Score", initialScore);
        Debug.Log($"Score set to {initialScore}.");

        // Ensure PlayerPrefs are saved immediately
        PlayerPrefs.Save();
    }
}
