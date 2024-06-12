using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : MonoBehaviour
{
    public void PlayMenu()
    {
        GameObject yello = GameObject.Find("YELLO");
        Destroy(yello);
        SceneManager.LoadScene(0);
    }
}
