using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToScene : MonoBehaviour
{
    public string SceneName; // Name of the scene to load when starting the game
    
    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(SceneName))
        {
            Debug.LogError("Scene name is not set!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the A button input
        if (OVRInput.GetDown(OVRInput.Button.One)) // "One" is the A button on the Meta Quest controller
        {
             SceneManager.LoadScene(SceneName);
        }
    }
}