using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Scene[] scenes = SceneManager.GetAllScenes();

        foreach (Scene sc in scenes)
            Debug.Log("'" + sc.name + "'");

    }
    public void PlayCredits()
    {
        SceneManager.LoadScene(4);
    }
}
