using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class PokeballBehavior : MonoBehaviour
{
    public Rigidbody pokeballRigidbody; // Assign the Rigidbody component of the Poké Ball
    public AudioSource audioSourceSuccess; // Assign an AudioSource for success
    public AudioSource audioSourceFailure; // Assign an AudioSource for failure
    public Transform pokeballTransform; // Assign the Transform of the Poké Ball
    public GameObject capturedObjectSuccess;  // Assign the object to appear on success
    public GameObject capturedObjectFailure;  // Assign the object to appear on failure
    public GameObject loadingCanvas;   // Reference to the UI Canvas that displays "Loading..." message

    public string successScene = "SuccessScene"; // Scene to load on success
    public string failureScene = "FailureScene"; // Scene to load on failure
    public float successThreshold = 5f; // Set the threshold for success (1-10)

    public float shakeAngle = 30f;     // Maximum angle for rocking motion
    public float shakeSpeed = 15f;     // Speed of the rocking motion
    public float randomShakeFactor = 5f; // Adds randomness to the rocking motion
    public float shakeDuration = 3f; // Duration of the shake effect

    private bool isShaking = false;
    private float shakeTimer = 0f;
    private bool hasPlayedAudio = false;
    private Quaternion originalRotation;

    private float loadingTimer = 0f;
    private bool isLoading = false;
    private bool isFailure = false; // Determines success or failure

    void Start()
    {
        // Ensure both captured objects are initially hidden
        if (capturedObjectSuccess != null)
        {
            capturedObjectSuccess.SetActive(false);
        }

        if (capturedObjectFailure != null)
        {
            capturedObjectFailure.SetActive(false);
        }

        // Ensure the loading canvas is initially hidden
        if (loadingCanvas != null)
        {
            loadingCanvas.SetActive(false);
        }

        // Position the loading canvas in front of the camera (relative to the VR Camera Rig)
        if (loadingCanvas != null)
        {
            loadingCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f; // 2 units in front of the camera
        }
    }

    void Update()
    {
        // Start shaking when velocity is close to zero
        if (!isShaking && pokeballRigidbody.velocity.magnitude < 0.01f && !hasPlayedAudio)
        {
            StartShaking();
        }

        // Handle shaking
        if (isShaking)
        {
            shakeTimer += Time.deltaTime;

            // Perform rocking motion with added randomness
            float shakeAngleOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAngle;
            float randomOffset = Random.Range(-randomShakeFactor, randomShakeFactor);
            pokeballTransform.rotation = originalRotation * Quaternion.Euler(0, 0, shakeAngleOffset + randomOffset);

            // Stop shaking after duration
            if (shakeTimer >= shakeDuration)
            {
                StopShaking();
            }
        }

        // Handle loading screen timer
        if (isLoading)
        {
            loadingTimer += Time.deltaTime;
            if (loadingTimer >= 3f) // Wait for 3 seconds before loading the next scene
            {
                LoadNextScene();
            }
        }
    }

    private void StartShaking()
    {
        // Determine success or failure
        int randomValue = Random.Range(1, 11); // Random value between 1 and 10
        isFailure = randomValue > successThreshold;

        // Play the appropriate audio
        if (!isFailure && audioSourceSuccess != null)
        {
            audioSourceSuccess.Play();
        }
        else if (isFailure && audioSourceFailure != null)
        {
            audioSourceFailure.Play();
        }

        hasPlayedAudio = true;

        // Save the original rotation for rocking motion
        originalRotation = pokeballTransform.rotation;

        // Initialize shake state
        isShaking = true;
        shakeTimer = 0f;
    }

    private void StopShaking()
    {
        // Stop shaking and reset rotation
        pokeballTransform.rotation = originalRotation;

        // Show the appropriate captured object
        if (!isFailure && capturedObjectSuccess != null)
        {
            capturedObjectSuccess.SetActive(true);
        }
        else if (isFailure && capturedObjectFailure != null)
        {
            capturedObjectFailure.SetActive(true);
        }

        // Activate the loading canvas
        if (loadingCanvas != null)
        {
            loadingCanvas.SetActive(true);
        }

        // Start the loading screen timer
        isLoading = true;

        isShaking = false;
        shakeTimer = 0f;
    }

    private void LoadNextScene()
    {
        // Load the appropriate scene based on success or failure
        string sceneToLoad = isFailure ? failureScene : successScene;
        SceneManager.LoadScene(sceneToLoad);
    }
}
