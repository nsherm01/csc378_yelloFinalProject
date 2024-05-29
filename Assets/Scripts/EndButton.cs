using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void EndGame()
    {
        GameObject yello = GameObject.Find("YELLO");
        yello.transform.position = new Vector2(-5f, -3.6f);
        SceneManager.LoadScene(4);
    }
}
