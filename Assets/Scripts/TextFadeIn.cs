using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1; i += 0.2f * Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            Debug.Log(i);
            yield return null;
        }
    }
}