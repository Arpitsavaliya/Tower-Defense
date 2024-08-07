using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static BackgroundMusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            Debug.LogWarning("Multiple Music Managers on Scene. Desroying current.");
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
