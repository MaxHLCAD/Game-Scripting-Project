using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonSound; // Assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}