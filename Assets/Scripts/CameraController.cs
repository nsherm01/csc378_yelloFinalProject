using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minY = 0;
    public float maxY = 6.1f;
    public float offset;

    void Update()
    {
        Transform yello = GameObject.Find("YELLO").transform;
        Debug.Log(yello.position.y);
        if ((yello.position.y > minY) && (yello.position.y < maxY)) {
            transform.Translate(Vector2.up * (yello.position.y - transform.position.y));
        }
    }
}
