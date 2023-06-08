using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource; // Sound effects
    public AudioSource musicSource; // Background music
    public AudioClip backgroundMusic; // Assign your looping song here

    // Set the range for the random pitch adjustment
    public float lowPitchRange = 0.0001f;
    public float highPitchRange = 3.0f;

    private void Start()
    {
        // Set the clip and start playing
        musicSource.clip = backgroundMusic;
        musicSource.loop = true; // Loop the music
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        // Randomize the pitch
        sfxSource.pitch = Random.Range(lowPitchRange, highPitchRange);

        // Play the clip
        sfxSource.PlayOneShot(clip);
    }
}
