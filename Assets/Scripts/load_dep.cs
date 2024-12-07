using UnityEngine;

public class LoadObjectBasedOnPlayerPrefs : MonoBehaviour
{
    public GameObject poke1;
    public GameObject poke2;
    public GameObject poke3;
    public GameObject poke4;
    public GameObject poke5;
    public GameObject poke6;
    public GameObject poke7;
    public GameObject poke8;
    public GameObject poke9;
    public GameObject poke10;
    public GameObject poke11;
    public GameObject poke12;
    public GameObject poke13;
    public GameObject poke14;
    public GameObject poke15;

    void Start()
    {
        // Ensure both objects are initially inactive
        poke1.SetActive(false);
        poke2.SetActive(false);
        poke3.SetActive(false);
        poke4.SetActive(false);
        poke5.SetActive(false);
        poke6.SetActive(false);
        poke7.SetActive(false);
        poke8.SetActive(false);
        poke9.SetActive(false);
        poke10.SetActive(false);
        poke11.SetActive(false);
        poke12.SetActive(false);
        poke13.SetActive(false);
        poke14.SetActive(false);
        poke15.SetActive(false);


        // Retrieve the object type from PlayerPrefs
        string objectType = PlayerPrefs.GetString("ObjectClicked");

        // Check the object type and activate the corresponding GameObject
        if (objectType == "abra")
        {
            poke1.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "buizel")
        {
            poke2.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "croconaw")
        {
            poke3.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "cynda")
        {
            poke4.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "pikachu")
        {
            poke5.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "kadabra")
        {
            poke6.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "larvitar")
        {
            poke7.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "machoke")
        {
            poke8.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "minun")
        {
            poke9.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "charizard")
        {
            poke10.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "deliberd")
        {
            poke11.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "deoxys")
        {
            poke12.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "marsh")
        {
            poke13.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "meow")
        {
            poke14.SetActive(true);  // Activate the frog GameObject
        }

        if (objectType == "sneasel")
        {
            poke15.SetActive(true);  // Activate the frog GameObject
        }
    }
}