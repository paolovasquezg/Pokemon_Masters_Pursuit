using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    // Public variables to assign in the Inspector
    public TextMeshProUGUI dialogueText; // TextMeshProUGUI for dialogue display
    public string[] dialogueLines; // Array of dialogue lines
    public string nextSceneName; // Name of the next scene to load

    private int currentLineIndex = 0; // Tracks the current dialogue line

    // Start is called before the first frame update
    void Start()
    {
        // Display the first dialogue line, if available
        if (dialogueLines.Length > 0)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            Debug.LogWarning("No dialogue lines set in the DialogueManager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the A button input (Meta Quest 2 controller)
        if (OVRInput.GetDown(OVRInput.Button.One)) // "One" maps to the A button
        {
            AdvanceDialogue();
        }
    }

    // Advances the dialogue or transitions the scene
    void AdvanceDialogue()
    {
        if (currentLineIndex < dialogueLines.Length - 1)
        {
            // Move to the next dialogue line
            currentLineIndex++;
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            // Last dialogue line reached, transition to the next scene
            LoadNextScene();
        }
    }

    // Loads the specified scene
    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set in the DialogueManager!");
        }
    }
}
