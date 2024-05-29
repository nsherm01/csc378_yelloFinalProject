using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottom : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject yello = GameObject.Find("YELLO");
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2) {
            yello.transform.position = new Vector2(yello.transform.position.x, 5);
            SceneManager.LoadScene(1);
        }
        else if (scene == 3) {
            yello.transform.position = new Vector2(yello.transform.position.x, 5);
            SceneManager.LoadScene(2);
        }
    }
}
