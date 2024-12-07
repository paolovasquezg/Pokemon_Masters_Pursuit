using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsToScenes : MonoBehaviour
{
    public string ASceneName;
    public string BSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(ASceneName))
        {
            Debug.LogError("Scene name A is not set!");
        }

        if (string.IsNullOrEmpty(BSceneName))
        {
            Debug.LogError("Scene name B is not set!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the A button input
        if (OVRInput.GetDown(OVRInput.Button.One)) // "One" is the A button on the Meta Quest controller
        {
             SceneManager.LoadScene(ASceneName);
        }

        if (OVRInput.GetDown(OVRInput.Button.Two)) // "Two" is the B button on the Meta Quest controller
        {
             SceneManager.LoadScene(BSceneName);
        }
    }
}