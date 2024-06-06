using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject yello = GameObject.Find("YELLO");
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 1) {
            yello.transform.position = new Vector2(-6f, -3.6f);
            SceneManager.LoadScene(2);
        }
        else if (scene == 2) {
            yello.transform.position = new Vector2(-6f, -3.6f);
            SceneManager.LoadScene(3);
        }
        else if (scene == 3)
        {
            yello.transform.position = new Vector2(0f, -3.6f);
            SceneManager.LoadScene(5);
        }
        else if (scene == 6)
        {
            yello.transform.position = new Vector2(0f, -3.6f);
            SceneManager.LoadScene(1);
        }
    }
}
