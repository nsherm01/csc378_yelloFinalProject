using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying){
            audioSource.Play();
        }
    }
}
