using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneFromLoading : MonoBehaviour
{
    public string nextScene;

    void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        asyncLoad.allowSceneActivation = false;

        // Debug to track loading progress
        while (!asyncLoad.isDone)
        {
            Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");

            // When loading is almost done, activate the new scene
            if (asyncLoad.progress >= 0.9f)
            {
                Debug.Log("Scene loading complete. Activating scene...");
                asyncLoad.allowSceneActivation = true;
            }
            yield return null; // Continue to next frame
        }
    }
}
