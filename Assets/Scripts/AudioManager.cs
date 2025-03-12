using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip wing;
    public AudioClip death;
    public static AudioManager instance;

    [SerializeField] AudioSource audioSource;

    // Update is called once per frame
    public void playAudio(AudioClip a)
    {
        audioSource.PlayOneShot(a);
    }
}
