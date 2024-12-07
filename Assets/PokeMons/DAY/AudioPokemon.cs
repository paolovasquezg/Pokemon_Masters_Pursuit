using UnityEngine;

public class AudioPokemon : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip[] audioClips; // Clips de audio para elegir
    public float timeBetweenAudios = 5.0f; // Intervalo entre reproducciones
    public bool playRandomly = true; // ¿Reproducir en orden aleatorio?

    [Header("3D Audio Settings")]
    public float maxDistance = 30.0f; // Distancia máxima de audición
    public float minDistance = 1.0f; // Distancia mínima para el volumen máximo

    private AudioSource audioSource;
    private float timer;

    void Start()
    {
        // Agregar un AudioSource al NPC si no tiene uno
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configuración inicial del AudioSource
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.spatialBlend = 1.0f; // 1.0f para audio completamente 3D
        audioSource.maxDistance = maxDistance; // Configurar distancia máxima de audición
        audioSource.minDistance = minDistance; // Configurar distancia mínima de audición
        audioSource.rolloffMode = AudioRolloffMode.Linear; // Cambiar volumen linealmente con la distancia

        timer = timeBetweenAudios; // Inicializar el temporizador

    }

    void Update()
    {
        // Reducir el temporizador
        timer -= Time.deltaTime;

        // Si el temporizador llega a 0, reproducir un audio
        if (timer <= 0f && audioClips.Length > 0)
        {
            PlayAudioClip();
            timer = timeBetweenAudios; // Reiniciar el temporizador
        }


    }

    private void PlayAudioClip()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("El array de audioClips está vacío. No hay clips para reproducir.");
            return;
        }

        if (playRandomly)
        {
            // Seleccionar un clip al azar
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            Debug.Log($"Clip seleccionado aleatoriamente: {audioSource.clip?.name ?? "Ninguno"} (índice {randomIndex})");
        }
        else
        {
            // Seleccionar el siguiente clip en orden
            int nextIndex = (int)(Time.time / timeBetweenAudios) % audioClips.Length;
            audioSource.clip = audioClips[nextIndex];
            Debug.Log($"Clip seleccionado en orden: {audioSource.clip?.name ?? "Ninguno"} (índice {nextIndex})");
        }

        // Validar si el clip está asignado
        if (audioSource.clip == null)
        {
            Debug.LogError("No se ha asignado ningún clip al AudioSource. Revisa el array de audioClips.");
            return;
        }

        // Verificar la distancia al jugador
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Debug.Log("Distancia al jugador: " + distance);

        // Intentar reproducir el clip
        Debug.Log($"Intentando reproducir el clip: {audioSource.clip.name}");
        audioSource.Play();

        // Registrar estado del AudioSource después de Play
        Debug.Log($"Estado del AudioSource: isPlaying = {audioSource.isPlaying}, volume = {audioSource.volume}, spatialBlend = {audioSource.spatialBlend}");
    }

}
