using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Top : MonoBehaviour
{
    internal Animator animator;
    public AudioSource audioSource;
    public AudioClip finishAudio;

    public Canvas endButton;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        endButton = GetComponent<Canvas>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject yello = GameObject.Find("YELLO");
        yello.transform.position = new Vector2(yello.transform.position.x, -0.54f);
        SceneManager.LoadScene(5);
    }
}
