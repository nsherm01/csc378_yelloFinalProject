using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScreenFlicker : MonoBehaviour
{
    public Image buttonImage;
    public Sprite off;
    public Sprite on;
    public float interval = 0.5f;

    void Start()
    {
        if (off != null && on != null)
        {
            StartCoroutine(Flicker());
        }
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            buttonImage.sprite = on;
            yield return new WaitForSeconds(interval * 3.5f);

            buttonImage.sprite = off;
            yield return new WaitForSeconds(interval);
        }
    }
}
