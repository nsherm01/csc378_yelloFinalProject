using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFadeIn : MonoBehaviour
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
        while(alpha < 1f)
        {
            alpha += .1f * Time.deltaTime;
            c2.a = alpha;
            renderer.color = c2;
            yield return null;
        }
        renderer.color = new Color(c2.r,c2.g,c2.b,1f);
    }
}
