using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene2TransitionOnCollision : MonoBehaviour
{
    public GameObject TriggerObject;
    public string loadingScene;
    private bool isSceneLoading = false; // To prevent multiple scene loads

    void Start() {
        if (TriggerObject == null) {
            Debug.LogWarning("Trigger box not assigned!"); // Warn if no collider is assigned
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!isSceneLoading && other.gameObject == TriggerObject) { // Check that the collider matches
            Debug.LogWarning("Trigger Activated");
            isSceneLoading = true;      // Prevent multiple triggers
            StartCoroutine(LoadSceneAsync());  // Start the asynchronous loading coroutine
        }
    }

    private IEnumerator LoadSceneAsync() {
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingScene);
        asyncLoad.allowSceneActivation = false;

        // Debug to track loading progress
        while (!asyncLoad.isDone) {
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");

            // When loading is almost done, activate the new scene
            if (asyncLoad.progress >= 0.9f) {
                Debug.Log("Scene loading complete. Activating scene...");
                asyncLoad.allowSceneActivation = true;
            }
            yield return null; // Continue to next frame
        }
    }
}
