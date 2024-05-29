using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpetualLightFade : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        c.a = 0f;
        renderer.color = c;

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float alpha = 0f;
        Color c2 = renderer.color;
        while (true)
        {
            alpha += .25f * Time.deltaTime;
            float temp = Mathf.Sin(alpha);
            if(temp > 0)
            {
                c2.a = temp;
            } else
            {
                c2.a = 0f;
            }
            renderer.color = c2;
            yield return null;
        }
    }
}
