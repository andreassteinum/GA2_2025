using UnityEngine;

public class AmbiancePlayer : MonoBehaviour
{
    public AudioClip ambienceClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = ambienceClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f; // Adjust volume here (0 to 1)

        audioSource.Play();
    }

}
