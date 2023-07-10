using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    public AudioClip musicClip; // The audio clip to be played

    private AudioSource audioSource;

    private void Start()
    {
        // Create an AudioSource component if not already attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the audio clip to be played
        audioSource.clip = musicClip;

        // Play the music
        audioSource.Play();
    }
}
