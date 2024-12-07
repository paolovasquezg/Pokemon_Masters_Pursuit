using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScoreAndLoadScene : MonoBehaviour
{
    public string targetScene; // The name of the scene to load if the score is 2

    void Start()
    {
        // Retrieve the value of "Score" from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0); // Default to 0 if "Score" doesn't exist

        // Check if the value is 2
        if (score == 1)
        {
            Debug.Log("Score is 2. Loading scene: " + targetScene);
            SceneManager.LoadScene(targetScene); // Load the specified scene
        }
        else
        {
            Debug.Log("Score is not 2. Current score: " + score);
        }
    }
}
