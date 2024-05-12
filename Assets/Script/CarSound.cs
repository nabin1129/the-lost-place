using UnityEngine;

public class CarSound : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float detectionRange = 5f; // Range within which the sound is audible
    public AudioClip carSound; // Sound to be played when player is in range
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the car
    }

    void Update()
    {
        // Check if the player is within the detection range
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // Player is within range, play the car sound
            if (!audioSource.isPlaying) // Check if the sound is not already playing to avoid overlap
            {
                audioSource.clip = carSound;
                audioSource.Play();
            }
        }
        else
        {
            // Player is not within range, stop the sound if it's playing
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
