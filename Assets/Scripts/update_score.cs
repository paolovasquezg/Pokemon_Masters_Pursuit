using UnityEngine;
using UnityEngine.UI;

public class UpdateTextFromPlayerPrefs : MonoBehaviour
{
    public Text textElement;          // Assign your Text UI element in the Inspector
    public Text additionalText;       // The Text UI element to show when the condition is met
    public int triggerValue = 5;      // The value to check against (e.g., when score/2 == triggerValue)
    public GameObject[] gameObjectsToDeactivate;  // List of GameObjects to deactivate
    public GameObject puerta;
    public GameObject final;
    public GameObject flecha;

    void Start()
    {

        final.SetActive(false);
        flecha.SetActive(false);
        // Retrieve the value of "Score" from PlayerPrefs and update the text
        if (PlayerPrefs.HasKey("Score"))
        {
            int score = PlayerPrefs.GetInt("Score", 0); // Default to 0 if key is missing

            // Set the first Text element to display the score divided by 2
            textElement.text = ": " + score.ToString();

            // Check if score / 2 equals or exceeds the trigger value
            if (score >= triggerValue)            {
                puerta.SetActive(true);
                flecha.SetActive(true);
                // If score / 2 >= 15, change the additional text
                if (score >= 15)
                {
                    additionalText.text = "Dirígete a la puerta final";
                    final.SetActive(true);
                }

                // Make the additional text visible
                additionalText.gameObject.SetActive(true);

                // Deactivate all specified GameObjects
                foreach (GameObject obj in gameObjectsToDeactivate)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                // Hide the additional text if the condition isn't met
                puerta.SetActive(false);
                additionalText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Default to showing "Score: 0" if no score is found
            textElement.text = ": 0";
            additionalText.gameObject.SetActive(false);  // Hide additional text if score doesn't exist
        }
    }
}
